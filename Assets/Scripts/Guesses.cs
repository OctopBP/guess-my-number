using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Game
{
    public class Guesses
    {
        readonly ObjectPool<GuessResultView> guessesPool;
        readonly List<GuessResultView> shownGuesses = new();
        
        public Guesses(GuessResultView guessResultViewPrefab, Transform guessesParent)
        {
            guessesPool = new(
                createFunc: () => Object.Instantiate(guessResultViewPrefab, guessesParent),
                actionOnGet: g => g.gameObject.SetActive(true),
                actionOnRelease: g => g.gameObject.SetActive(false));
        }

        public void Add(GuessResult guessResult)
        {
            var view = guessesPool.Get();
            view.SetResult(guessResult);
            shownGuesses.Add(view);
        }
        
        public void Hide()
        {
            foreach (var shownGuess in shownGuesses)
            {
                guessesPool.Release(shownGuess);
            }
        }
    }
}