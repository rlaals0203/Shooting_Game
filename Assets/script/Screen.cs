using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        Debug.Log("restart");
        gameObject.SetActive(false);
        GameManager.instance.bStart = true;
    }
}
