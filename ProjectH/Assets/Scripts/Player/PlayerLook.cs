using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerLook : MonoBehaviour
    {
        #region Content

        [SerializeField] 
        private Camera _camera;
        public Camera Camera => _camera;

        [SerializeField] private Transform _weapon;
        
        [SerializeField] private float _xSensivity = 30f, _ySensivity = 30f, _lookXLimit = 80f;

        #endregion

        #region Fields

        private float _xRotation = 0f;

        #endregion

        
        #region Process: Look

        public void ProcessLook(Vector2 input)
        {
            var mouseX = input.x;
            var mouseY = input.y;

            _xRotation -= (mouseY * Time.deltaTime * _ySensivity);
            _xRotation = Mathf.Clamp(_xRotation, -_lookXLimit, _lookXLimit);
            _weapon.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * _xSensivity));
        }

        #endregion
    }
}