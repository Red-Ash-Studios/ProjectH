using ProjectH.Scripts.Player;
using UnityEngine;

namespace ProjectH.Scripts.Enemy
{
    public class Bullet : MonoBehaviour
    {
        private float _destroyTime;
        
        private void OnCollisionEnter(Collision collision)
        {
            Transform hitTransform = collision.transform;
            if (hitTransform.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
                hitTransform.GetComponent<PlayerStats>().DecreaseHealth(10);
            }
            Destroy(gameObject, 1);
        }

        private void Start()
        {
            Destroy(gameObject, 5);
        }
    }
}