using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneScripts : MonoBehaviour
{
    public void OnClickExit()
    {
        SceneManager.LoadScene(0);
    }
}
