using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Keypad : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] Button button;
        
        int number;
        public event Action<int> OnClick;

        void Start()
        {
            button.onClick.AddListener(() => OnClick?.Invoke(number));
        }
        
        public void SetNumber(int number)
        {
            this.number = number;
            text.SetText($"{number}");
        }
    }
}