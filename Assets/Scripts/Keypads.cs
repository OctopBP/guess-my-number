using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Game
{
    public class Keypads
    {
        readonly ObjectPool<Keypad> keysPool;
        public event Action<int> OnNumberEnter;

        readonly List<Keypad> activeKeypads;
        
        public Keypads(Keypad keypadPrefab, Transform keypadsParent)
        {
            keysPool = new(
                createFunc: () => Object.Instantiate(keypadPrefab, keypadsParent),
                actionOnGet: keypad => keypad.gameObject.SetActive(true),
                actionOnRelease: keypad => keypad.gameObject.SetActive(false));
            
            activeKeypads = new(9);
        }

        public void Show()
        {
            // Shuffle numbers
            var rng = new Random();
            var numbers = Enumerable.Range(1, 9).OrderBy(_ => rng.Next()).ToList();

            foreach (var number in numbers)
            {
                var keypad = keysPool.Get();
                keypad.SetNumber(number);
                keypad.OnClick += EmitKeyClick;
                activeKeypads.Add(keypad);
            }
        }
        
        public void Hide()
        {
            foreach (var keypad in activeKeypads)
            {
                keypad.OnClick -= EmitKeyClick;
                keysPool.Release(keypad);
            }
            activeKeypads.Clear();
        }
        
        void EmitKeyClick(int number) => OnNumberEnter?.Invoke(number);
    }
}