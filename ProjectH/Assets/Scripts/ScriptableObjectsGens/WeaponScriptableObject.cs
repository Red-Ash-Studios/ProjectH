using UnityEngine;

namespace ProjectH.Scripts.ScriptableObjectsGen
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "bediitaner/Weapon/New Weapon", order = 1)]
    public class WeaponScriptableObject : ScriptableObject
    {
        #region Weapon: Info

        [Header("Info")]
        [SerializeField] 
        private string _weaponName;
        public string WeaponName => _weaponName;

        #endregion

        #region Weapon: Prefabs

        [Header("Prefab")]
        [SerializeField]
        private GameObject _prefab;
        public GameObject Prefab => _prefab;
        
        [SerializeField]
        private GameObject _muzzleFlash; 
        public GameObject MuzzleFlash => _muzzleFlash;
        
        [SerializeField]
        private GameObject _bulletHoleGraphic;
        public GameObject BulletHoleGraphic => _bulletHoleGraphic;

        #endregion

        #region Weapon: Stats

        [Header("Stats")]
        [SerializeField] 
        private int _damage;
        public int Damage => _damage;

        [SerializeField] 
        private int _magazineSize;
        public int MagazineSize => _magazineSize;
        
        [SerializeField] 
        private float _fireRate;
        public float FireRate => _fireRate;
        
        [SerializeField] 
        private int bulletsPerTap;
        public int BulletsPerTap => bulletsPerTap;
        
        [SerializeField] 
        private float _spread;
        public float Spread => _spread;
        
        [SerializeField] 
        private float _range;
        public float Range => _range;
        
        [SerializeField] 
        private float _reloadTime;
        public float ReloadTime => _reloadTime;
        
        [SerializeField] 
        private float _shotInterval;
        public float ShotInterval => _shotInterval;

        [SerializeField] 
        private float _aimSpeed;
        public float AimSpeed => _aimSpeed;
        
        [SerializeField] 
        private float _camShakeMagnitude;
        public float CamShakeMagnitude => _camShakeMagnitude;
        [SerializeField] 
        private float _camShakeDuration;
        public float CamShakeDuration => _camShakeDuration;

        #endregion

        #region Weapon: Type

        [Header("Type")]
        [SerializeField] 
        private bool _isAutomatic;
        public bool IsAutomatic => _isAutomatic;
        
        [SerializeField] 
        private bool _isBurst;
        public bool IsBurst => _isBurst;
        
        [SerializeField] 
        private bool _isSingle;
        public bool IsSingle => _isSingle;

        #endregion
    }
}