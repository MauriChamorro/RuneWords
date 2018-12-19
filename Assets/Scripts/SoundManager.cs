using System.Linq;
using UnityEngine;

public class SoundManager : GenericSingleton<SoundManager>
{
    public AudioSource asSFX;
    public AudioSource asMusic;
    private bool playSFX;

    public AudioClip[] sFXClips;
    public AudioClip[] musicClips;
    public AudioClip[] elementClips;

    protected override void Awake()
    {
        base.Awake();

        foreach (AudioSource item in GetComponentsInChildren<AudioSource>())
        {
            if (item.name == "SFX")
            {
                asSFX = item;
            }
            else if (item.name == "AmbientSound")
            {
                asMusic = item;
            }
        }
    }

    #region Play

    public void PlayElementSound(string pNameElement)
    {
        if (!playSFX)
            asSFX.PlayOneShot(elementClips.FirstOrDefault(c => c.name == pNameElement));
    }

    public void PlaySFXClipName(string pName)
    {
        if (!playSFX)
            asSFX.PlayOneShot(sFXClips.FirstOrDefault(c => c.name == pName));
    }

    public void SetMusicClipName(string pName)
    {
        asMusic.clip = musicClips.FirstOrDefault(c => c.name == pName);
    }

    public void PlayMusicClipName()
    {
        asMusic.Play();
    }

    public void ChangeVolumeMusic(float pVolume)
    {
        asMusic.volume = pVolume;
    }

    public void ChangeVolumeSFX(float pVolume)
    {
        asSFX.volume = pVolume;
    }

    public void ChangeMuteMusic(bool pMute)
    {
        // true: no reproducir musica
        if (pMute)
            asMusic.Stop();
        else
            asMusic.Play();
    }

    public void ChangeMuteSFX(bool pMute)
    {
        // true: no reproducir musica
        //if (pMute)
        //    asSFX.Stop();
        //else
        //    asSFX.Play();

        playSFX = pMute;
    }

    #endregion
}
