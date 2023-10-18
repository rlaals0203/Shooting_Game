using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    private Renderer render;
    public float nSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bStart)
        {
            Vector2 vec = new Vector2(0, Time.time * nSpeed);
        render.material.mainTextureOffset = vec;
        }
    }
}
