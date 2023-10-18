using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void onClick()
    {
        gameObject.SetActive(false);
        GameManager.instance.g_nHP = 5;
        GameManager.instance.g_nScore = 0;
        GameManager.instance.bStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.g_nHP <= 0)
        {
            gameObject.SetActive(true);
        }
    }
}
