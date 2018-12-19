using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class TrajectorySen : Trajectory, ITrajectory
    {

        public TrajectorySen(ITrajectoryValues valuesForTrayectorias) : base(valuesForTrayectorias)
        {
            this.Name = "Sen";
        }

        public Vector2 AxisMovement(float x, float y, float pStarPosX, float pStarPosY, float pVelChange)
        {
            return
                new Vector2(
                    (((x + Values.VelDesplX * pVelChange) * Values.DirectionX) + ((pStarPosX + Mathf.Sin(Values.VelOscillationX * pVelChange * Time.time)) * Values.OscillationX)),
                    (((y + Values.VelDesplY * pVelChange) * Values.DirectionY) + ((pStarPosY + Mathf.Sin(Values.VelOscillationY * pVelChange * Time.time)) * Values.OscillationY))
                    );
        }
    }
}
