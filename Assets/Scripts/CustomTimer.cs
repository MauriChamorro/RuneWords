using System;

namespace Assets.Scripts
{
    //[Serializable]
    public class CustomTimer
    {
        private float CurrentTime;
        private float CurrentDecTime;
        private float LimitTime;

        private void SetValues(float pLimit)
        {
            CurrentTime = 0f;
            LimitTime = pLimit;
            CurrentDecTime = LimitTime;
        }

        public CustomTimer(float pLimit)
        {
            SetValues(pLimit);
        }

        public void Restart(float pNewLimit)
        {
            SetValues(pNewLimit);
        }

        public void Update(float pDeltaTime)
        {
            CurrentDecTime -= pDeltaTime;

            if (CurrentDecTime <= 0)
                CurrentDecTime = 0;

            CurrentTime += pDeltaTime;
        }

        public string TimeOnSeconds(TimeType pTimeType)
        {
            double auxTime = 0;

            switch (pTimeType)
            {
                case TimeType.Current:
                    auxTime = CurrentTime;
                    break;
                case TimeType.Limit:
                    auxTime = LimitTime;
                    break;
                case TimeType.CurrentDecTime:
                    auxTime = CurrentDecTime;
                    break;
            }

            return Math.Floor(auxTime % 60f).ToString();
        }

        /// <summary>
        /// Verdadero cuando se cumple CurrentTime == LimitTime
        /// </summary>
        public bool OnTime()
        {
            return CurrentDecTime == 0f;
        }

        public enum TimeType
        {
            Current = 0,
            Limit = 1,
            CurrentDecTime = 2
        }

        public void AddSeconds(float pSeconds)
        {
            CurrentDecTime += pSeconds;
        }

        public void RestSeconds(float pSeconds)
        {
            CurrentDecTime -= pSeconds;

            if (CurrentDecTime <= 0)
            {
                CurrentDecTime = 0;
            }
        }

    }
}
