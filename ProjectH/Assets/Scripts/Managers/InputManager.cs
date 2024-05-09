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

        private PlayerMotor _motor;
        private PlayerLook _look;

        #endregion
        
        #region Unity

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _character = _playerInput.Character;
            
            _motor = GetComponent<PlayerMotor>();
            _look = GetComponent<PlayerLook>();
            
            _character.Jump.performed += ctx => _motor.Jump();
            _character.Sprint.performed += ctx => _motor.Sprint();
            _character.Crouch.performed += ctx => _motor.Crouch();
        }
        private void FixedUpdate()
        {
            
        }

        private void LateUpdate()
        {
            _motor.ProcessMove(_character.Movement.ReadValue<Vector2>());
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