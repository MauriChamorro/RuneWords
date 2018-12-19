using Assets.Scripts.Interfaces;
using System;

namespace Assets.Scripts.ValuesForTrajectory
{
    [Serializable]
    public class TrajectoryValues : ITrajectoryValues
    {
        public float DirectionX { get; protected set; }
        public float DirectionY { get; protected set; }
        public float VelDesplX { get; protected set; }
        public float VelDesplY { get; protected set; }
        public float OscillationX { get; protected set; }
        public float OscillationY { get; protected set; }
        public float VelOscillationX { get; protected set; }
        public float VelOscillationY { get; protected set; }
        public float Limit { get; protected set; }
        public float VelChange { get; protected set; }
    }
}
