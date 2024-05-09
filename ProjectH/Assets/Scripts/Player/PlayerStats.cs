using ProjectH.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectH.Scripts.Player
{
    public class PlayerStats: MonoBehaviour
    {
        #region Contents
        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthBarUI _healthBarUI;

        [Header("Damage Overlay")] 
        public Image _overlay;
        public float Duration;
        public float FadeSpeed;
        
        #endregion

        #region Fields

        private float _currentHealth;
        private float _durationTimer;

        #endregion

        #region Unity: Start | Update
        private void Start()
        {
            _currentHealth = _maxHealth;
            _currentHealth = Mathf.Clamp(_currentHealth,0, _maxHealth);

            DisableDamageOverlay();
            
            _healthBarUI.SetSliderMaxValue(_maxHealth);
            _healthBarUI.SetSliderStartingValue(_currentHealth);
            _healthBarUI.SetUIText(_currentHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                DecreaseHealth(20f);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                IncreaseHealth(20f);
            }

            UpdateDamageOverlay();

            if (_currentHealth <= 0)
            {
                Death();
            }
        }

        #endregion


        #region Overlay: Damage: Update

        private void UpdateDamageOverlay()
        {
            if (_overlay.color.a > 0)
            {
                if (_currentHealth < 30)
                    return;
                
                _durationTimer += Time.deltaTime;
                if (_durationTimer > Duration)
                {
                    float tempAlpha = _overlay.color.a;
                    tempAlpha -= Time.deltaTime * FadeSpeed;
                    _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, tempAlpha);
                }
            }
        }

        #endregion

        #region Overlay: Damage: Enable

        private void EnableDamageOverlay()
        {
            _durationTimer = 0;
            _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 1);
        }

        #endregion
        
        #region Overlay: Damage: Disable

        private void DisableDamageOverlay()
        {
            _overlay.color = new Color(_overlay.color.r, _overlay.color.g, _overlay.color.b, 0);
        }

        #endregion
        
        
        #region Health: Decrease

        public void DecreaseHealth(float damage)
        {
            var cachedValue = _currentHealth;
            
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            EnableDamageOverlay();

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue,_currentHealth);
        }

        #endregion

        #region Health: Increase

        public void IncreaseHealth(float amount)
        {
            var cachedValue = _currentHealth;

            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue,_currentHealth);
        }

        #endregion
        
        #region Death

        private void Death()
        {
            Debug.Log("Player is Dead!");
            
            //TODO:@Halit: Play Death Animation
            //TODO:@Halit: Activate Death UI 
            //TODO:@Halit: Disable Player Movement
            //TODO:@Halit: Disable Player Look
            //TODO:@Halit: Stop the game
        }

        #endregion
    }
}