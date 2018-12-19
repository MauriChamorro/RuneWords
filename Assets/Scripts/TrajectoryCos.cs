using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class TrajectoryCos : Trajectory, ITrajectory
    {
        public TrajectoryCos(ITrajectoryValues pTrajectoryValues) : base(pTrajectoryValues)
        {
            this.Name = "Cos";
        }

        public Vector2 AxisMovement(float x, float y, float pStarPosX, float pStarPosY, float pVelChange)
        {
            return
                new Vector2(
                    (((x + Values.VelDesplX) * Values.DirectionX) + ((pStarPosX + Mathf.Cos(Values.VelOscillationX * Time.time)) * Values.OscillationX)),
                    (((y + Values.VelDesplY) * Values.DirectionY) + ((pStarPosY + Mathf.Cos(Values.VelOscillationY * Time.time)) * Values.OscillationY))
                    );
        }
    }
}
