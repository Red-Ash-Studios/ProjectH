using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Properties

        [SerializeField] private float _gravity = -9.8f, _speed = 5f, _jumpHeight = 1f;

        #endregion

        #region Fields

        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _isGrounded;
        private bool _sprinting;
        private bool _crouching;
        private bool _lerpCrouch;
        private float _crouchTimer;

        #endregion


        #region Unity: Start | Update

        private void Start()
        {
            _controller = GetComponent<CharacterController>();

            SetCursor();
        }

        private void Update()
        {
            _isGrounded = _controller.isGrounded;

            AllowCrouch();
        }

        #endregion


        #region Set: Cursor

        private void SetCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        #endregion


        #region Process: Move

        public void ProcessMove(Vector2 input)
        {
            var moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            _controller.Move(transform.TransformDirection(moveDirection) * (_speed * Time.deltaTime));

            _playerVelocity.y += _gravity * Time.deltaTime;
            if (_isGrounded && _playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }

            _controller.Move(_playerVelocity * Time.deltaTime);
        }

        #endregion

        #region Process: Jump

        public void Jump()
        {
            if (_isGrounded)
            {
                _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
            }
        }

        #endregion

        #region Process: Sprint

        public void Sprint()
        {
            _sprinting = !_sprinting;
            if (_sprinting)
                _speed = 8;
            else
                _speed = 5;
        }

        #endregion

        #region Process: Crouch

        public void Crouch()
        {
            _crouching = !_crouching;
            _crouchTimer = 0;
            _lerpCrouch = true;
        }

        #endregion


        #region Allow: Crouch

        private void AllowCrouch()
        {
            if (_lerpCrouch)
            {
                _crouchTimer += Time.deltaTime;
                var progress = Mathf.Pow(_crouchTimer / 1, 2);
                var targetHeight = _crouching ? 1f : 2f;

                _controller.height = Mathf.Lerp(_controller.height, targetHeight, progress);

                if (progress >= 1f)
                {
                    _lerpCrouch = false;
                    _crouchTimer = 0f;
                }
            }
        }

        #endregion
    }
}