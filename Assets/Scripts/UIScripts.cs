using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIScripts : MonoBehaviour
{
    bool isPause = false;
    bool canTogglePause = true;

    [Header("StageNumber")]
    [SerializeField] TextMeshProUGUI stageText;


    // Start is called before the first frame update
    void Start()
    {
        stageText.text = "Stage: " + (SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {
        if(canTogglePause) isPause = !isPause;
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void NegatePause()
    {
        canTogglePause = false;
    }
}
