using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject Shoot;
    public float fGravity = 100.0f;
    public float fSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bStart)
        {
            
            transform.Translate(Input.GetAxisRaw("Horizontal") * fSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * fSpeed * Time.deltaTime, 0);


            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(Shoot, transform.position, transform.rotation);
            }
        }
    }
}
