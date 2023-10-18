using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public float fInterval = 2f;
    public float ItemfInterval = 30.0f;
    public GameObject Normal;
    public GameObject Gold;
    public GameObject Speedy;
    public GameObject Ruby;
    public GameObject Sapire;
    public GameObject Diamond;
    public GameObject Obsidian;
    public GameObject Dmg;
    public GameObject Gravity;
    public GameObject Health;
    Stopwatch sw = new Stopwatch();
    public bool IsDmg = false;
    public bool IsGrav = false;
    public bool IsHP = false;
    public int HP = 5;
    float nDmgTime = 0;
    float nGravTime = 0;
    float nHealTime = 0;
    public int g_nHP = 5;
    public int g_nScore = 0;
    public Text textScore;
    public Text textHP;
    public GameObject Button;
    public bool bStart = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("zetRandom", 0.1f, fInterval);
        InvokeRepeating("itemRandom", 0.1f, ItemfInterval);

        textScore.text = "스코어 : 0";
        textHP.text = "체력 : 5";

    }

    public static GameManager instance
    {
        get
        {
            return self;
        }
    }
    private static GameManager self;

    // Start is called before the first frame update
    void Awake()
    {
        if (self)
        {
            DestroyImmediate(gameObject);
            return;
        }
        self = this;
        DontDestroyOnLoad(gameObject); //  게임 매니저가 지속되도록 한다
    }



    // Update is called once per frame
    void Update()   
    {
        textScore.text = "스코어 : " + g_nScore.ToString();
        textHP.text = "체력 : " + g_nHP.ToString();

        if (IsDmg == true)
        {
            nDmgTime += Time.deltaTime;
            if (nDmgTime >= 10)
                IsDmg = false;
        }

        if (IsGrav == true)
        {
            nGravTime += Time.deltaTime;
            if (nGravTime >= 10)
                IsGrav = false;
        }

        if (IsHP == true)
        {
            nHealTime += Time.deltaTime;
            if (nGravTime >= 10)
                IsHP = false;
        }
    }
    void zetRandom()
    {
        if (!GameManager.instance.bStart)
            return;

            Vector3 pos = transform.position;
        pos.x = Random.Range(-3f, 3f);
        float num = Random.Range(1, 10000);
        if (num > 4000 && num <= 10000)
        {
            Instantiate(Normal, pos, transform.rotation);
        }
        else if (num > 2500 && num <= 4000)
        {
            Instantiate(Speedy, pos, transform.rotation);
        }
        else if (num > 1000 && num <= 2500)
        {
            Instantiate(Gold, pos, transform.rotation);
        }
        else if(num > 650 && num <= 1000)
        {
            Instantiate(Ruby, pos, transform.rotation);
        }
        else if(num > 300 && num <= 650)
        {
            Instantiate(Sapire, pos, transform.rotation);
        }
        else if(num > 100 && num <= 300)
        {
            Instantiate(Diamond, pos, transform.rotation);
        }
        else
        {
            Instantiate(Obsidian, pos, transform.rotation);
        }
    }

    void itemRandom()
    {
        if (!GameManager.instance.bStart)
            return;

        Vector3 pos = transform.position;
        pos.x = Random.Range(-3f, 3f);
        float num = Random.Range(1, 100);
        if (num > 0 && num <= 33)
        {
            Instantiate(Dmg, pos, transform.rotation);
        }
        else if(num > 33 && num <= 66)
        {
            Instantiate(Health, pos, transform.rotation);
        }
        else
        {
            Instantiate(Gravity, pos, transform.rotation);
        }
    }

    public void AddScore(int score)
    {
        g_nScore += score;
    }

    public void AddHP(int HP)
    {
        g_nHP += HP;
        if (g_nHP <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        bStart = false;
        Button.SetActive(true);
    }
}
