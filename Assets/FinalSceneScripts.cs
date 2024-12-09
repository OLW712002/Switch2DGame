using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneScripts : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CheckMusic());
    }

    IEnumerator CheckMusic()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        FindObjectOfType<GameSession>().MusicSettingForScenes();
    }

    public void OnClickExit()
    {
        FindObjectOfType<GameSession>().NeedChangeMusic();
        SceneManager.LoadScene(0);
    }
}
