using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject settingPopUp;
    [SerializeField] GameObject creditPopUp;

    void Start()
    {
        StartCoroutine(CheckMusic());
    }

    IEnumerator CheckMusic()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        FindObjectOfType<GameSession>().MusicSettingForScenes();
    }

    public void OpenSetting()
    {
        settingPopUp.SetActive(true);
    }

    public void OpenCredit()
    {
        creditPopUp.SetActive(true);
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().NeedChangeMusic();
    }

    public void OnClickSettingButton()
    {
        settingPopUp.SetActive(true);
    }

    public void OnClickCreditButton()
    {
        creditPopUp.SetActive(true);
    }

    public void OnClickExit()
    {
        settingPopUp.SetActive(false);
        creditPopUp.SetActive(false);
    }
}
