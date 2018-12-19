using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject health;
        public GameObject healthTrans;

        private Level currentLevel;
        public GameObject MenuPanel;
        public TrajectoryManager trajectoryManager;
        public SoundManager soundManager;
        public CustomTimer countToPlay;

        public Text levelText;
        public Text gameOverText;
        public Text countToPlayText;
        public Slider Clock;

        public float currentClockLerp;
        public float percClock;

        public Transform minHealth;
        public float speedTimeHealth;
        public float currentHealthTime;
        public float journeyLength;
        public float perc;
        private bool playing;

        public Text[] textButtons;

        private void Awake()
        {
            soundManager = SoundManager.Instance;

            SetGame();

            SetLevel();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                MenuPanel.SetActive(MenuPanel.gameObject.activeSelf ? false : true);

                //GeneralGameValues.StopGame();

                soundManager.PlaySFXClipName("menu-game");
            }

            if (!playing)
            {
                #region countToPlayText
                if (countToPlayText.enabled)
                {
                    if (countToPlay.OnTime())
                    {
                        StartGame();

                        trajectoryManager.StartGame(currentLevel.CantElementSpanw);

                        return;
                    }

                    countToPlay.Update(Time.deltaTime);
                    countToPlayText.text = countToPlay.TimeOnSeconds(CustomTimer.TimeType.CurrentDecTime);

                    if (countToPlayText.text == "3")
                    {
                        //imagen 1
                    }

                    if (countToPlayText.text == "2")
                    {
                        //imagen 2
                    }

                    if (countToPlayText.text == "1")
                    {
                        //imagen 3
                    }

                    if (countToPlayText.text == "0")
                    {
                        countToPlayText.text = "GO";
                        //imagen go
                    }
                }
                #endregion
            }

            if (playing)
            {
                if (Clock.value <= 0f && health.transform.position.y > minHealth.transform.position.y/*health.transform.position.y >= currentLevel.MaxHealth*/)
                {
                    if (currentLevel.GameWon())
                    {
                        GameOver(true);

                        return;
                    }

                    LevelUp();

                    return;
                }
                else
                if (health.transform.position.y <= -9.5f)
                {
                    GameOver(false);

                    return;
                }

                if (Input.GetButton("Fire1"))
                {
                    RayOnElement();
                }

                #region Lerp for Clock
                currentClockLerp += Time.deltaTime;
                if (currentClockLerp > currentLevel.ClockTime)
                {
                    currentClockLerp = currentLevel.ClockTime;
                }

                percClock = currentClockLerp / currentLevel.ClockTime;

                Clock.value = Mathf.Lerp(currentLevel.ClockTime, 0f, percClock);
                #endregion

                #region Lerp for Health
                currentHealthTime += Time.deltaTime * speedTimeHealth;

                if (currentHealthTime > journeyLength)
                {
                    currentHealthTime = journeyLength;
                }

                perc = currentHealthTime / journeyLength;

                health.transform.position = Vector3.Lerp(
                    health.transform.position,
                    minHealth.position,
                    perc);

                healthTrans.transform.position = Vector3.Lerp(
                   healthTrans.transform.position,
                   minHealth.position,
                   perc);

                #endregion
            }
        }

        private void SetGame()
        {
            playing = false;
            GeneralGameValues.ResumeGame();

            if (countToPlay == null)
                countToPlay = new CustomTimer(GeneralGameValues.TiempoConteo);
            else
                countToPlay.Restart(GeneralGameValues.TiempoConteo);

            countToPlayText.enabled = true;

            if (currentLevel == null)
                currentLevel = new Level();
        }

        private void SetLevel()
        {
            gameOverText.enabled = false;

            health.transform.position = new Vector3(0f, currentLevel.MaxHealth, 93f);
            healthTrans.transform.position = new Vector3(1.5f, currentLevel.MaxHealth, 93f);
            currentHealthTime = 0f;
            speedTimeHealth = currentLevel.SpeedHealth;
            journeyLength = Vector3.Distance(health.transform.position, minHealth.position);

            currentClockLerp = 0f;
            Clock.maxValue = currentLevel.ClockTime;
            Clock.value = currentLevel.ClockTime;

            switch (currentLevel.NumLevel)
            {
                case 1:
                    levelText.text = "Nivel 1";
                    break;
                case 2:
                    levelText.text = "Nivel 2";
                    break;
                case 3:
                    levelText.text = "Nivel 3";
                    break;
                default:
                    levelText.text = "TERMINÓ MAL";
                    break;
            }

            print("CantSpawn-->" + currentLevel.CantElementSpanw);
            print("ClockTime-->" + currentLevel.ClockTime);
            print("SpeedHealth-->" + currentLevel.SpeedHealth);
        }
		
	}
}
