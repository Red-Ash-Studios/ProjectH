using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectH.Scripts.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _txtHealth;

        #endregion
        

        #region Slider: Set

        public void SetSliderStartingValue(float currentValue)
        {
            _slider.value = currentValue;
        }

        #endregion

        #region Slider: Set: Max

        public void SetSliderMaxValue(float maxAmount)
        {
            _slider.maxValue = maxAmount;
        }

        #endregion

        #region Slider: Update

        public void UpdateSliderValue(float updatedAmount)
        {
            _slider.DOValue(updatedAmount, 0.5f);
        }

        #endregion


        #region Text: Set

        public void SetUIText(float currentHealth)
        {
            _txtHealth.text = $"{currentHealth}";
        }

        #endregion

        #region Text: Update

        public void UpdateUIText(float currentValue, float updatedAmount)
        {
            DOTween.To(() => currentValue, x => currentValue = Mathf.RoundToInt(x), updatedAmount, 0.5f)
                .OnUpdate(() => _txtHealth.text = $"{currentValue}");

            var startColor = currentValue < updatedAmount ? Color.green : Color.gray;

            DOTween.To(() => _txtHealth.color, x => _txtHealth.color = x, startColor, 0.5f)
                .OnComplete(() => _txtHealth.color = Color.white);
        }

        #endregion
    }
}