using UnityEngine;

namespace Gameplay.Weapon
{
    public class WeaponSway : MonoBehaviour
    {
        #region Content

        [Header("Position")] 
        [SerializeField] private float _amount = 0.02f;
        [SerializeField] private float _maxAmount = 0.06f;
        [SerializeField] private float _smoothAmount = 6f;
        [Header("Rotation")] 
        [SerializeField] private float _rotationAmount = 4f;
        [SerializeField] private float _maxRotationAmount = 5f;
        [SerializeField] private float _smoothRotation = 12f;

        [Space] 
        [SerializeField] private bool rotationX = true, rotationY = true, rotationZ = true;

        #endregion

        #region Fields

        private Vector3 initialPosition;
        private Quaternion initialRotation;

        private float InputX, InputY;

        #endregion

        
        #region Unity: Start | Update

        private void Start()
        {
            initialPosition = transform.localPosition;
            initialRotation = transform.localRotation;
        }

        private void Update()
        {
            CalculateSway();
            MoveSway();
            TiltSway();
        }

        #endregion

        
        #region Sway: Calculate

        private void CalculateSway()
        {
            InputX = Input.GetAxis("Mouse X");
            InputY = Input.GetAxis("Mouse Y");
        }
        

        #endregion

        #region Sway: Move

        private void MoveSway()
        {
            float moveX = Mathf.Clamp(InputX * _amount, -_maxAmount, _maxAmount);
            float moveY = Mathf.Clamp(InputY * _amount, -_maxAmount, _maxAmount);

            Vector3 finalPosition = new Vector3(moveX, moveY, 0);

            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition,
                Time.deltaTime * _smoothAmount);
        }

        #endregion

        #region Sway: Tilt

        private void TiltSway()
        {
            float tiltY = Mathf.Clamp(InputX * _rotationAmount, -_maxRotationAmount, _maxRotationAmount);
            float tiltX = Mathf.Clamp(InputY * _rotationAmount, -_maxRotationAmount, _maxRotationAmount);

            Quaternion finalRotation = Quaternion.Euler(new Vector3(rotationX ? -tiltX : 0f, rotationY ? tiltY : 0f,
                rotationZ ? tiltY : 0f));

            transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation,
                _smoothRotation * Time.deltaTime);
        }

        #endregion
    }
}