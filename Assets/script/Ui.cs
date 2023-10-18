using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public GameObject obj;
    public float interval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onClick()
    {
        GameManager.instance.bStart = true;
        gameObject.SetActive(false);
        InvokeRepeating("spawnObj", 0.1f, interval);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
