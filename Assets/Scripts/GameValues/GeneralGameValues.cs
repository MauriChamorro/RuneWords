namespace Assets.Scripts
{
    public static class GeneralGameValues
    {
        public static float MaxHealth = -1.4f;
        public static float MinHealth = -10f;
        public static float TiempoReloj = 20f;
        public static float TiempoConteo = 4f;
        public static float SlowTimeStarted = 1f;
        public static float VolumneMusic = 0.8f;
        public static float VolumeSFX = 1f;
        public static bool MutedMusic = false;
        public static bool MutedSFX = false;
        public static int CantElemetsSpawn = 120;
        public static float SpeedLife = 0.001f;

        public static void StopGame()
        {
            SlowTimeStarted = 0f;
        }

        public static void ResumeGame()
        {
            SlowTimeStarted = 1f;
        }
    }
}
