using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Item : MonoBehaviour
{
    public float Time;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shoot")
        {
            if(gameObject.tag == "Dmg")
            {
                GameManager.instance.IsDmg = true;
            }
            else if (gameObject.tag == "Gravity")
            {
                GameManager.instance.IsGrav = true;
            }
            else
            {
                GameManager.instance.IsHP = true;
            }
            Health -= 1;
            if (Health == 0)
            {
                //GameObject.Find("GameManager").GetComponent<GameManager>().AddScore();
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bStart)
        {
            if (transform.position.y < -5)
                Destroy(gameObject);
        }
    }
}
