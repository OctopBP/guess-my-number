using UnityEngine;

namespace Game
{
    class GameConfig
    {
        public readonly RangeInt numberRange;
        
        public GameConfig(RangeInt numberRange)
        {
            this.numberRange = numberRange;
        }
    }
}