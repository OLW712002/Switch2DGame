using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickups : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("ImChecking");
        if (transform.childCount == 0)
        {
            Debug.Log("NextLevel");
            Invoke("NextLevel", 1.5f);
        }
    }

    void NextLevel()
    {
        int numScene = SceneManager.sceneCountInBuildSettings;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex == numScene) nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
