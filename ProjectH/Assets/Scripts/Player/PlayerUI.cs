using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ProjectH.Scripts.Player
{
    public class PlayerUI : MonoBehaviour
    {
        #region Content

        [SerializeField] private TextMeshProUGUI _prompText;

        #endregion
        
        #region Unity: Start | Update

        void Start()
        {
        }

        public void UpdateText(string promptMessage)
        {
            _prompText.text = promptMessage;
        }

        #endregion
    }
}