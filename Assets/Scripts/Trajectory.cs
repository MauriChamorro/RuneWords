using Assets.Scripts.Interfaces;

namespace Assets.Scripts
{
    public class Trajectory
    {
        public string Name { get; set; }
        public ITrajectoryValues Values { get; private set; }

        public Trajectory(ITrajectoryValues pTrajectoryValues)
        {
            Values = pTrajectoryValues;
        }
    }
}
