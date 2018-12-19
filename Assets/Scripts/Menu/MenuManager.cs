using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using Assets.Scripts;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    public GameObject[] menuPanels = new GameObject[4];

    public SoundManager soundManager;

    public Text[] textButtons;
    public Font[] fonts;

    public Toggle mutedMusic;
    public Toggle mutedSFX;
    public Slider volumeMusic;
    public Slider volumeSFX;

    void Start()
    {
        soundManager = SoundManager.Instance;

        SetMusicClipName("MenuMusic");

        GetPrayerPrefs();
        ChangeVolumeMusic();
        ChangeVolumeSFX();
        ChangeMuteMusic();
        ChangeMuteSFX();

        //SelectPanel("MenuPanel");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PlaySFXClipName("back-menu");
            SelectPanel("MenuPanel");
        }
    }

    public void StartGame()
    {
        PlaySFXClipName("select-button");

        SetMusicClipName("GammingMusic");
        if (!mutedMusic.isOn)
            PlayMusicClipName();

        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region UI Events

    public void PointerEnterText(string pNameText)
    {
        Text auxText = textButtons.FirstOrDefault(t => t.name == pNameText);
        if (auxText)
        {
            auxText.font = fonts.FirstOrDefault(f => f.name == "CODE Bold");
            auxText.fontSize = 40;
            PlaySFXClipName("over-button");
        }
    }

    public void PointerExitText(string pNameText)
    {
        Text auxText = textButtons.FirstOrDefault(t => t.name == pNameText);
        auxText.font = fonts.FirstOrDefault(f => f.name == "CODE Light");
        auxText.fontSize = 20;
    }

    #endregion

    #region UI Sounds Events

    public void SelectPanel(string pNamePanel)
    {

        foreach (GameObject panel in menuPanels)
        {

            if (panel.name == pNamePanel)
            {
                panel.SetActive(true);
                soundManager.PlaySFXClipName("select-button");
            }
            else
            {
                panel.SetActive(false);
            }
        }


        foreach (Text item in textButtons)
        {
            item.font = fonts.FirstOrDefault(f => f.name == "CODE Light");
            item.fontSize = 20;
        }
    }

    public void PlaySFXClipName(string pName)
    {
        soundManager.PlaySFXClipName(pName);
    }

    public void SetMusicClipName(string pName)
    {
        soundManager.SetMusicClipName(pName);
    }

    public void PlayMusicClipName()
    {
        soundManager.PlayMusicClipName();
    }


    public void ChangeMuteMusic()
    {
        //mutedSFX.isOn --> true: apagar la musica
        PlayerPrefs.SetInt("mutedMusic", Convert.ToInt32(mutedMusic.isOn));
        volumeMusic.interactable = !mutedMusic.isOn;
        soundManager.ChangeMuteMusic(mutedMusic.isOn);
    }

    public void ChangeMuteSFX()
    {
        //mutedSFX.isOn --> true: apagar la musica
        PlayerPrefs.SetInt("mutedSFX", Convert.ToInt32(mutedSFX.isOn));
        volumeSFX.interactable = !mutedSFX.isOn;
        soundManager.ChangeMuteSFX(mutedSFX.isOn);
    }

    public void ChangeVolumeMusic()
    {
        PlayerPrefs.SetFloat("volumeMusic", volumeMusic.value);
        soundManager.ChangeVolumeMusic(volumeMusic.value);
    }

    public void ChangeVolumeSFX()
    {
        PlayerPrefs.SetFloat("volumeSFX", volumeSFX.value);
        soundManager.ChangeVolumeSFX(volumeSFX.value);
    }

    public void GetPrayerPrefs()
    {
        if (PlayerPrefs.HasKey("mutedMusic"))
            mutedMusic.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("mutedMusic"));
        else
        {
            mutedMusic.isOn = GeneralGameValues.MutedMusic;
            PlayerPrefs.SetInt("mutedMusic", Convert.ToInt32(mutedMusic.isOn));
        }

        if (PlayerPrefs.HasKey("mutedSFX"))
            mutedSFX.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("mutedSFX"));
        else
        {
            mutedSFX.isOn = GeneralGameValues.MutedSFX;
            PlayerPrefs.SetInt("mutedSFX", Convert.ToInt32(mutedSFX.isOn));
        }

        if (PlayerPrefs.HasKey("volumeMusic"))
            volumeMusic.value = PlayerPrefs.GetFloat("volumeMusic");
        else
        {
            volumeMusic.value = GeneralGameValues.VolumneMusic; //ACA TENER VALOR POR DEFECTO
            PlayerPrefs.SetFloat("volumeMusic", volumeMusic.value);
        }

        if (PlayerPrefs.HasKey("volumeSFX"))
            volumeSFX.value = PlayerPrefs.GetFloat("volumeSFX");
        else
        {
            volumeSFX.value = GeneralGameValues.VolumeSFX; //ACA TENER VALOR POR DEFECTO
            PlayerPrefs.SetFloat("volumeSFX", volumeSFX.value);
        }
    }
    #endregion


}

