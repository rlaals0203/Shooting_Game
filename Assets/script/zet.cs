using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class zet : MonoBehaviour
{
    public int Health;
    public int score;
    public int HP = -1;
    bool IsActive = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shoot")
        {
            if (GameManager.instance.IsDmg == true)
            {
                Debug.Log("Dmg");
                Health -= 2;
            }
            else
                Health -= 1;

            if (Health <= 0)
            {
                GameManager.instance.AddScore(score);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.bStart)
        {
            if (GameManager.instance.IsGrav == true && IsActive == false)
            {
                IsActive = true;
                Debug.Log("grav");
                Rigidbody2D RD = GetComponent<Rigidbody2D>();
                RD.gravityScale -= RD.gravityScale * 0.4f;
            }

            if (GameManager.instance.IsGrav == false)
                IsActive = false;

            if (GameManager.instance.IsHP == true)
            {
                GameManager.instance.g_nHP -= 1;
                if (GameManager.instance.g_nHP <= 0)
                {
                    GameManager.instance.GameOver();
                }
            }

            if (transform.position.y < -5)
            {
                GameManager.instance.AddHP(HP);
                Destroy(gameObject);
            }
        }
        else
            Destroy(gameObject);
    }
}
