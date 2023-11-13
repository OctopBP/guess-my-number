using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Keypad : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] Button button;
        
        int number;
        public readonly Subject<int> onClick = new();

        void Start()
        {
            button.onClick.AddListener(() => onClick.OnNext(number));
        }
        
        public void SetNumber(int value)
        {
            number = value;
            text.SetText($"{value}");
        }
    }
}