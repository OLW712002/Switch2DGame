using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    UIScripts UIScripts;
    private void Start()
    {
        UIScripts = FindObjectOfType<UIScripts>();
    }
    private void Update()
    {
        if (transform.childCount == 0)
        {
            UIScripts.NegateDying();
            StartCoroutine(CompleteLevel());
        }
    }

    IEnumerator CompleteLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        UIScripts.ShowGameCompleteScreen();
    }
}
