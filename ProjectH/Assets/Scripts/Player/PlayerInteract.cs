using ProjectH.Scripts.Managers;
using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        #region Content

        [SerializeField] private float _distance = 3f;

        [SerializeField] private LayerMask _layerMask;

        #endregion

        #region Fields

        private Camera _cam;
        private PlayerUI _playerUI;
        private InputManager _inputManager;

        #endregion
        
        #region Unity: Start | Update

        private void Start()
        {
            _cam = GetComponent<PlayerControls>().Camera;
            _playerUI = GetComponent<PlayerUI>();
            _inputManager = GetComponent<InputManager>();
        }

        private void Update()
        {
            UpdateText();
        }

        #endregion

        
        #region Text: Update

        private void UpdateText()
        {
            _playerUI.UpdateText(string.Empty);
            var ray = new Ray(_cam.transform.position, _cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * _distance);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, _distance, _layerMask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    var interactable = hitInfo.collider.GetComponent<Interactable>();
                    _playerUI.UpdateText(interactable.PromptMessage);
                    // if (_inputManager.Character.Interact.triggered)
                    // {
                    //     interactable.BaseInteract();
                    // }
                }
            }
        }

        #endregion
    }
}