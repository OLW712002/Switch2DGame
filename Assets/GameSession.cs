using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] AudioSource mainMenuMussic;
    [SerializeField] AudioSource chillingMusic;
    [SerializeField] AudioSource seriousMusic;
    [SerializeField] AudioSource congratulationMusic;

    bool isMusicOn = true;
    static bool needChangeMusic = true;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        MusicSettingForScenes();
    }

    public void MusicSettingForScenes()
    {
        if (!needChangeMusic) return;
        EnsureAudioSourceEnabled(mainMenuMussic);
        EnsureAudioSourceEnabled(chillingMusic);
        EnsureAudioSourceEnabled(seriousMusic);
        EnsureAudioSourceEnabled(congratulationMusic);

        StopAllMusic();

        int numActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (numActiveSceneIndex == 0 && isMusicOn)
        {
            mainMenuMussic.Play();
        }
        else if (numActiveSceneIndex < 5 && isMusicOn)
        {
            chillingMusic.Play();
        }
        else if (numActiveSceneIndex < 10 && isMusicOn)
        {
            seriousMusic.Play();
        }
        else if (numActiveSceneIndex == 10 && isMusicOn)
        {
            congratulationMusic.Play();
        }
        needChangeMusic = false;
    }

    public void NeedChangeMusic()
    {
        needChangeMusic = true;
    }

    void EnsureAudioSourceEnabled(AudioSource audioSource)
    {
        if (!audioSource.isActiveAndEnabled)
        {
            audioSource.enabled = true;
        }
    }


    public void StopAllMusic()
    {
        if (mainMenuMussic.isPlaying) mainMenuMussic.Stop();
        if (chillingMusic.isPlaying) chillingMusic.Stop();
        if (seriousMusic.isPlaying) seriousMusic.Stop();
        if (congratulationMusic.isPlaying) congratulationMusic.Stop();
    }

    public void SetMusicOn()
    {
        isMusicOn = true;
        mainMenuMussic.Play();
    }

    public void SetMusicOff()
    {
        StopAllMusic();
        isMusicOn = false;
    }

    public bool CheckMusicOn()
    {
        return isMusicOn;
    }
}
