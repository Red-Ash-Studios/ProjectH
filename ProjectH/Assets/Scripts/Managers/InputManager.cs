using System;
using ProjectH.Scripts.Player;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectH.Scripts.Managers
{
    public class InputManager : NetworkBehaviour
    {
        #region Fields

        private PlayerInput _playerInput;
        private PlayerInputActions _playerInputActions;

        private PlayerControls _playerControls;

        #endregion

        #region Unity
        
        private void Start()
        {
            if (!IsOwner)
                return;
            
            _playerControls = GetComponent<PlayerControls>();
            _playerInputActions = new PlayerInputActions();
            _playerInput = GetComponent<PlayerInput>();
            _playerInputActions.Enable();

            AddEvents();
        }

        private void FixedUpdate()
        {
        }

        private void LateUpdate()
        {
            if (!IsOwner)
                return;
            
            _playerControls.ProcessLook(_playerInputActions.Character.Look.ReadValue<Vector2>());
            _playerControls.ProcessMove(_playerInputActions.Character.Movement.ReadValue<Vector2>());
        }

        #endregion


        #region Event: OnJumped

        private void OnJumped(InputAction.CallbackContext obj)
        {
            _playerControls.Jump();
        }

        #endregion

        #region Event: OnSprinted

        private void OnSprinted(InputAction.CallbackContext obj)
        {
            _playerControls.Sprint();
        }

        #endregion

        #region Event: OnCrouched

        private void OnCrouched(InputAction.CallbackContext obj)
        {
            _playerControls.Crouch();
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            _playerInputActions.Character.Sprint.performed += OnSprinted;
            _playerInputActions.Character.Jump.performed += OnJumped;
            _playerInputActions.Character.Crouch.performed += OnCrouched;
        }

        private void RemoveEvents()
        {
            _playerInputActions.Character.Sprint.performed -= OnSprinted;
            _playerInputActions.Character.Jump.performed -= OnJumped;
            _playerInputActions.Character.Crouch.performed -= OnCrouched;
        }

        #endregion
    }
}