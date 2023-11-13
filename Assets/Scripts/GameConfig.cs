using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "Game/Config", fileName = "GameConfig")]
    class GameConfig : ScriptableObject
    {
        [SerializeField] int minNumber, maxNumber;

        public RangeInt numberRange => new RangeInt(minNumber, maxNumber - minNumber + 1);
    }
}