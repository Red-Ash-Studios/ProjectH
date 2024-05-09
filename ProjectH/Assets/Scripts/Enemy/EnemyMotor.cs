using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace ProjectH.Scripts.Enemy
{
    public class EnemyMotor : MonoBehaviour
    {
        #region Content

        [Header("Path")]
        [SerializeField] private Path _path;
        public Path Path => _path;

        [Header("Sight Values")] 
        [SerializeField] private float _eyeHeight;
        [SerializeField] private float _sightDistance = 20f;
        [SerializeField] private float _fieldOfView = 85f;

        [Header("Weapon Values")]
        [SerializeField] private Transform _gunBarrel;
        [Range(0.1f, 10f)]
        [SerializeField] private float _fireRate;
        public float FireRate => _fireRate;

        [Header("Debug")]
        [SerializeField] private GameObject _debugSphere;        
        [SerializeField] private string _currentState;
        
        [Header("Enemy Stats")]
        [SerializeField]
        private EnemyStats _enemyStats;
        public EnemyStats EnemyStats => _enemyStats;
        #endregion
        
        #region Properties

        private NavMeshAgent _agent;
        private GameObject _player;
        private Vector3 _lastKnownPosition;

        public NavMeshAgent Agent => _agent;
        public GameObject Player => _player;
        public Vector3 LastKnownPosition {
            get => _lastKnownPosition;
            set => _lastKnownPosition = value;
        }

        #endregion
        
        #region Fields
        
        private StateMachine _stateMachine;

        #endregion

        #region Unity: Start | Update

        private void Start()
        {
            _stateMachine = GetComponent<StateMachine>();
            _agent = GetComponent<NavMeshAgent>();
            _stateMachine.Initialize();
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            EnemyCanSeePlayer();
            _currentState = _stateMachine.activeState.ToString();
            _debugSphere.transform.position = _lastKnownPosition;
        }

        #endregion

        
        #region Enemy: CanSeePlayer

        public bool EnemyCanSeePlayer()
        {
            if (_player != null)
            {
                //is the player close enough to be seen? 
                if (Vector3.Distance(transform.position, _player.transform.position) < _sightDistance)
                {
                    Vector3 targetDirection = _player.transform.position - transform.position - Vector3.up * _eyeHeight;
                    float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                    if (angleToPlayer >= -_fieldOfView && angleToPlayer <= _fieldOfView)
                    {
                        Ray ray = new Ray(transform.position + Vector3.up * _eyeHeight, targetDirection);
                        RaycastHit hitInfo = new RaycastHit();

                        if (Physics.Raycast(ray, out hitInfo, _sightDistance))
                        {
                            if (hitInfo.transform.gameObject == _player)
                            {
                                Debug.DrawRay(ray.origin, ray.direction * _sightDistance, Color.red);
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        #endregion

        #region Enemy: Shoot

        public void Shoot()
        {
            //instantiate a new bullet 
            var bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject,_gunBarrel.position,gameObject.transform.rotation);
            
            //calculate the direction to shoot (player)
            var shootDirection = (_player.transform.position - _gunBarrel.position).normalized;
            //add force rigidbody the bullet
            bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f,3f),Vector3.up) * shootDirection * 60;
        }

        #endregion
    }
}