using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Game
{
    public class Keypads
    {
        readonly ObjectPool<Keypad> keysPool;
        public readonly Subject<int> onNumberEnter = new();

        readonly List<Keypad> activeKeypads;
        readonly RangeInt numberRange;
        
        public Keypads(Keypad keypadPrefab, Transform keypadsParent, RangeInt numberRange)
        {
            keysPool = new(
                createFunc: () =>
                {
                    var keypad = Object.Instantiate(keypadPrefab, keypadsParent);
                    keypad.onClick.Subscribe(onNumberEnter);
                    return keypad;
                },
                actionOnGet: keypad => keypad.gameObject.SetActive(true),
                actionOnRelease: keypad => keypad.gameObject.SetActive(false));
            
            activeKeypads = new(numberRange.length);

            this.numberRange = numberRange;
        }

        public void Show()
        {
            // Shuffle numbers
            var rng = new Random();
            var numbers = Enumerable.Range(numberRange.start, numberRange.length).OrderBy(_ => rng.Next()).ToList();

            foreach (var number in numbers)
            {
                var keypad = keysPool.Get();
                keypad.SetNumber(number);
                activeKeypads.Add(keypad);
            }
        }
        
        public void Hide()
        {
            foreach (var keypad in activeKeypads)
            {
                keysPool.Release(keypad);
            }
            activeKeypads.Clear();
        }
    }
}