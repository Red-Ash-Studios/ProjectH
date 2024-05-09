using System;
using ProjectH.Scripts.Player;
using UnityEngine;

namespace ProjectH.Scripts.Managers
{
    public class InputManager: MonoBehaviour
    {
        #region Fields

        private PlayerInput _playerInput;
        
        private PlayerInput.CharacterActions _character;
        public PlayerInput.CharacterActions Character => _character;

        private PlayerMovement _movement;
        private PlayerLook _look;

        #endregion
        
        #region Unity

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _character = _playerInput.Character;
            
            _movement = GetComponent<PlayerMovement>();
            _look = GetComponent<PlayerLook>();
            
            _character.Jump.performed += ctx => _movement.Jump();
            _character.Sprint.performed += ctx => _movement.Sprint();
            _character.Crouch.performed += ctx => _movement.Crouch();
        }
        private void FixedUpdate()
        {
            
        }

        private void LateUpdate()
        {
            _movement.ProcessMove(_character.Movement.ReadValue<Vector2>());
            _look.ProcessLook(_character.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _character.Enable();
        }

        private void OnDisable()
        {
            _character.Disable();
        }

        #endregion
    }
}