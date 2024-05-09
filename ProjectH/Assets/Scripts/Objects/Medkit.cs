using ProjectH.Scripts.Player;
using UnityEngine;

namespace ProjectH.Scripts.Objects
{
    public class MedKit : MonoBehaviour
    {
        [SerializeField] private float _healAmount;
        [SerializeField] private PlayerStats _playerStats;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().IncreaseHealth(_healAmount);
                Destroy(gameObject);
            }
        }

        public void Interact()
        {
            //refactor this
            _playerStats.IncreaseHealth(_healAmount);
            Destroy(gameObject);
        }
    }
}