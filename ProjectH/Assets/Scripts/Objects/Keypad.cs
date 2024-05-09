using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectH.Scripts.Objects
{
    public class Keypad : Interactable
    {
        #region Contents

        [SerializeField] private GameObject _door;
        [SerializeField] private Animator _animator;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _darkRed;
        [SerializeField] private Material _glowRed;

        #endregion

        #region Fields

        private bool _doorOpen;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        #endregion


        #region Unity: Start | Update

        private void Start()
        {
            SetButtonColor();
        }

        private void Update()
        {
        }

        #endregion


        #region Override: Interact

        protected override void Interact()
        {
            _doorOpen = !_doorOpen;
            _animator.SetBool(IsOpen, _doorOpen);

            SetButtonColor();
        }

        #endregion


        #region Set: Button: Color

        private void SetButtonColor()
        {
            _meshRenderer.material = _doorOpen ? _darkRed : _glowRed;
            
            // _keypadMaterial.color = _doorOpen ? Color.Lerp(Color.black, Color.red, 0.3f) : Color.red*2;
        }

        #endregion
    }
}