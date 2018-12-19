using System;

namespace Assets.Scripts
{
    [Serializable]
    public class Level
    {
        public int NumLevel { get; private set; }
        public int MaxLevel { get; private set; }
        public int CantElementSpanw { get; private set; } 
        public float VelLevel { get; private set; }
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }
        public float ClockTime { get; private set; }
        public float SpeedHealth { get; private set; }

        public Level()
        {
            NumLevel = 1;
            MaxLevel = 3;
            CantElementSpanw = GeneralGameValues.CantElemetsSpawn;
            VelLevel = GeneralGameValues.SlowTimeStarted;
            MaxHealth = GeneralGameValues.MaxHealth;
            MinHealth = GeneralGameValues.MinHealth;
            ClockTime = GeneralGameValues.TiempoReloj;
            SpeedHealth = GeneralGameValues.SpeedLife;
        }

        public void LevelUp()
        {
            NumLevel++;
            CantElementSpanw -= CantElementSpanw * 20 / 100;
            MaxHealth += MaxHealth * 40 / 100;
            ClockTime += ClockTime * 40 / 100;
            SpeedHealth += 0.0005f;
        }

        public bool GameWon()
        {
            return NumLevel == MaxLevel;
        }
    }
}
