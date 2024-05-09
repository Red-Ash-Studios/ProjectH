using ProjectH.Scripts.UI;
using UnityEngine;

namespace ProjectH.Scripts.Enemy
{
    public class EnemyStats : MonoBehaviour
    {
        #region Contents

        [SerializeField] private float _maxHealth;
        [SerializeField] private HealthBarUI _healthBarUI;

        #endregion

        #region Fields

        private float _currentHealth;
        private float _durationTimer;
        private bool _isEnemyDead;
        public bool IsEnemyDead => _isEnemyDead;

        #endregion

        #region Unity: Start | Update

        private void Start()
        {
            _currentHealth = _maxHealth;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            // DisableDamageOverlay();

            _healthBarUI.SetSliderMaxValue(_maxHealth);
            _healthBarUI.SetSliderStartingValue(_currentHealth);
            _healthBarUI.SetUIText(_currentHealth);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                DecreaseHealth(20f);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                IncreaseHealth(20f);
            }

            // UpdateDamageOverlay();

            if (_currentHealth <= 0)
            {
                if (!_isEnemyDead)
                {
                    Death();
                }
            }
        }

        #endregion


        #region Health: Decrease

        public void DecreaseHealth(float damage)
        {
            var cachedValue = _currentHealth;

            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            // EnableDamageOverlay();

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue, _currentHealth);
        }

        #endregion

        #region Health: Increase

        public void IncreaseHealth(float amount)
        {
            var cachedValue = _currentHealth;

            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

            _healthBarUI.UpdateSliderValue(_currentHealth);
            _healthBarUI.UpdateUIText(cachedValue, _currentHealth);
        }

        #endregion

        #region Death

        private void Death()
        {
            Debug.Log("Enemy is Dead!");
            
            _isEnemyDead = true;
            
            //TODO:@Halit: Play Death Animation
            //TODO:@Halit: Activate Death UI 
            //TODO:@Halit: Disable Player Movement
            //TODO:@Halit: Disable Player Look
            //TODO:@Halit: Stop the game
        }

        #endregion
    }
}