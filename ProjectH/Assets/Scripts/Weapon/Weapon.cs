using ProjectH.Scripts.Enemy;
using ProjectH.Scripts.ScriptableObjectsGen;
using TMPro;
using UnityEngine;

namespace ProjectH.Scripts.Weapon
{
    public class Weapon : MonoBehaviour
    {
        #region Contents

        [Header("Loadout")] 
        [SerializeField] private WeaponScriptableObject[] _loadoutArray;
        [SerializeField] private Transform _weaponParent;

        [Header("Graphics")] 
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _raycastTargets;
        [SerializeField] private TextMeshProUGUI _text;
        // public CamShake camShake;

        #endregion

        #region Fields
        
        private RaycastHit _rayHit;
        private WeaponScriptableObject _equipedWeapon;
        private GameObject _currentWeapon;

        private int _bulletsLeft;
        private int _bulletsShot;

        private bool _isShooting;
        private bool _isReadyToShoot;
        private bool _isReloading;

        #endregion


        #region Unity: Awake | Start | Update

        private void Awake()
        {
        }

        private void Start()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) WeaponEquip(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) WeaponEquip(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) WeaponEquip(2);

            if (_currentWeapon != null)
            {
                WeaponAim(Input.GetMouseButton(1));
                if (_equipedWeapon.IsAutomatic) _isShooting = Input.GetKey(KeyCode.Mouse0);
                else _isShooting = Input.GetKeyDown(KeyCode.Mouse0);
            }

            if (Input.GetKeyDown(KeyCode.R) && _bulletsLeft < _equipedWeapon.MagazineSize && !_isReloading) Reload();

            if (_isReadyToShoot && _isShooting && !_isReloading && _bulletsLeft > 0)
            {
                _bulletsShot = _equipedWeapon.BulletsPerTap;
                Shoot();
            }

            SetText();
        }

        #endregion


        #region Weapon: Equip

        private void WeaponEquip(int index)
        {
            //TODO: @Halit - Needs Refactor.
            if (_currentWeapon != null)
                Destroy(_currentWeapon);

            _equipedWeapon = _loadoutArray[index];

            var newWeapon = Instantiate(_equipedWeapon.Prefab, _weaponParent.position, _weaponParent.rotation,
                _weaponParent);

            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localEulerAngles = Vector3.zero;

            _bulletsLeft = _equipedWeapon.MagazineSize;
            _isReadyToShoot = true;

            _currentWeapon = newWeapon;
        }

        #endregion

        #region Weapon: Aim

        private void WeaponAim(bool isAiming)
        {
            var weaponAnchor = _currentWeapon.transform.Find("Anchor");
            var stateAds = _currentWeapon.transform.Find("States/ADS");
            var stateHip = _currentWeapon.transform.Find("States/Hip");


            if (isAiming)
            {
                weaponAnchor.position = Vector3.Lerp(weaponAnchor.position, stateAds.position,
                    Time.deltaTime * _equipedWeapon.AimSpeed);
            }
            else
            {
                weaponAnchor.position = Vector3.Lerp(weaponAnchor.position, stateHip.position,
                    Time.deltaTime * _equipedWeapon.AimSpeed);
            }
        }

        #endregion

        #region Weapon: Shoot

        private void Shoot()
        {
            _isReadyToShoot = false;

            //Spread
            float x = Random.Range(-_equipedWeapon.Spread, _equipedWeapon.Spread);
            float y = Random.Range(-_equipedWeapon.Spread, _equipedWeapon.Spread);

            //Calculate Direction with Spread
            Vector3 direction = _camera.transform.forward + new Vector3(x, y, 0);

            //RayCast
            if (Physics.Raycast(_camera.transform.position, direction, out _rayHit, _equipedWeapon.Range, _raycastTargets))
            {
                Debug.Log(_rayHit.collider.name);

                if (_rayHit.collider.CompareTag("Enemy"))
                    _rayHit.collider.GetComponentInParent<EnemyMotor>().EnemyStats.DecreaseHealth(_equipedWeapon.Damage);
                else
                    Debug.Log("Hit: Dağ Taş");
            }

            //ShakeCamera
            // camShake.Shake(camShakeDuration, camShakeMagnitude);

            //Graphics
            Instantiate(_equipedWeapon.BulletHoleGraphic, _rayHit.point, Quaternion.Euler(0, 180, 0));
            // Instantiate(_equipedWeapon.MuzzleFlash, attackPoint.position, Quaternion.identity);

            _bulletsLeft--;
            _bulletsShot--;

            Invoke("ResetShot", _equipedWeapon.ShotInterval);

            if (_bulletsShot > 0 && _bulletsLeft > 0)
                Invoke("Shoot", _equipedWeapon.FireRate);
        }

        private void ResetShot()
        {
            _isReadyToShoot = true;
        }

        #endregion

        #region Weapon: Reload

        private void Reload()
        {
            _isReloading = true;
            Invoke("ReloadFinished", _equipedWeapon.ReloadTime);
        }

        private void ReloadFinished()
        {
            _bulletsLeft = _equipedWeapon.MagazineSize;
            _isReloading = false;
        }

        #endregion
        
        
        #region Set: Text

        private void SetText()
        {
            if (_currentWeapon != null)
            {
                _text.SetText(_bulletsLeft + " / " + _equipedWeapon.MagazineSize);
            }
        }

        #endregion
    }
}