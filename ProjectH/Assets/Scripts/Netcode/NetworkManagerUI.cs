using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectH.Scripts.Netcode
{
    public class NetworkManagerUI : MonoBehaviour
    {
        [SerializeField] private Button _serverBtn;
        [SerializeField] private Button _hostBtn;
        [SerializeField] private Button _clientBtn;


        private void Awake()
        {
            AddListeners();
        }
    
        private void AddListeners()
        {
            _serverBtn.onClick.AddListener((() =>
            {
                NetworkManager.Singleton.StartServer();
            }));
            _hostBtn.onClick.AddListener((() =>
            {
                NetworkManager.Singleton.StartHost();
            }));
            _clientBtn.onClick.AddListener((() =>
            {
                NetworkManager.Singleton.StartClient();
            }));
        }

        private void RemoveListeners()
        {
        }
    }
}