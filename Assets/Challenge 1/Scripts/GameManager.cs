using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;

public class GameManager : MonoBehaviour
{
    private int hp = 3;
    private int ogHp = 3;

    private bool win = false;

    private GameObject _player;

    public int level = 1;

    [SerializeField] private TextMeshProUGUI txtWin;

    [SerializeField] private Button btnReiniciar;

    [SerializeField] private TextMeshProUGUI txtPoints;

    public static GameManager instance;
    [SerializeField] private GameObject[] _hpsImages;
    private int points;
    private int points2;
    private int dmg;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("A");
            Destroy(gameObject);
            instance.InitLevel();
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        btnReiniciar.onClick.AddListener(GameOver);
        InitLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage()
    {
        hp--;
        Debug.Log(hp);
        UpdateHp();
        dmg++;
        if (hp <= 0)
        {
            win = false;
            EndLevel("You died!");
        }
        else
        {
            _player.transform.rotation = Quaternion.identity;
            _player.transform.position = Vector3.zero;
        }
    }

    public void HpUp(int num)
    {
        hp += num;
        points += 100;
        txtPoints.text = "Points: " + points;
        Debug.Log(hp);
        UpdateHp();
    }

    public void Goal()
    {
        win = true;

        //500 points for finishing lvl - 20 x damage received on that lvl
        points += 500 - (20 * dmg);
        txtPoints.text = "Points: " + points;
        if (level == 1)
        {
            EndLevel("Congratulations, go to next level.");
        }
        else
        {
            EndLevel("YOU WIN!");
        }
    }

    private void EndLevel(string message)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        txtWin.text = message;
        txtWin.gameObject.SetActive(true);
        btnReiniciar.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void GameOver()
    {
        if (level == 1 && win)
        {
            win = false;
            level = 2;
            SceneManager.LoadScene("Level 2");
            ogHp = hp;
            points2 = points;
        }
        else if (level == 2 && !win)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            level = 1;
            SceneManager.LoadScene("GameOver");
        }

    }

    public void InitLevel()
    {
        _player = GameObject.FindWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        txtWin.gameObject.SetActive(false);
        btnReiniciar.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        
        if (level == 1)
        {
            ogHp = 3;
            points2 = 0;
        }

        dmg = 0;
        points = points2;
        hp = ogHp;

        UpdateHp();


        txtPoints.text = "Points: " + points;
        /*Vector3 offset = new Vector3(0,0,0);
        for (int i = 0; i < hp; i++)
        {
            Instantiate(_hpImage, _imgSpawn.transform.position + offset, Quaternion.identity);
            offset.x += 100;
        }/*
        //StartCoroutine(LateStart());
    }

    /*IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.01f);
        _player = GameObject.FindWithTag("Player");
    }*/
    }


    private void UpdateHp()
    {
        foreach (var obj in _hpsImages)
        {
            obj.SetActive(false);
        }
        
        for (int i = 0; i < hp; i++)
        {
            _hpsImages[i].SetActive(true);
        }
    }
}