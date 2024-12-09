using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIScripts : MonoBehaviour
{
    bool isPause = false;
    bool canTogglePause = true;
    bool canDying = true;

    [Header("StageNumber")]
    [SerializeField] TextMeshProUGUI stageText;

    [Header("GameStateController")]
    [SerializeField] GameObject pauseState;
    [SerializeField] GameObject gameOverState;
    [SerializeField] GameObject gameCompleteState;

    void Start()
    {
        stageText.text = "  Stage: " + (SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(CheckMusic());
    }

    IEnumerator CheckMusic()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        FindObjectOfType<GameSession>().MusicSettingForScenes();
    }

    public void TogglePause()
    {
        if(canTogglePause) isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
            pauseState.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseState.SetActive(false);
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverState.SetActive(true);
    }

    public void ShowGameCompleteScreen()
    {
        gameCompleteState.SetActive(true);
    }

    public void NegatePause()
    {
        canTogglePause = false;
    }

    public void NegateDying()
    {
        canDying = false;
    }

    public bool CheckImmortal()
    {
        return !canDying;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        int numScene = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == numScene) nextSceneIndex = 0;
        if (nextSceneIndex == 0 || nextSceneIndex == 1 || nextSceneIndex == 5 || nextSceneIndex == 10) FindObjectOfType<GameSession>().NeedChangeMusic();
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().StopAllMusic();
        Destroy(FindObjectOfType<GameSession>());
        Time.timeScale = 1;
    }


}
