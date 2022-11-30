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

    public static GameManager instance;
    private void Awake()
    {
        if(instance != null && instance != this)
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
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        hp--;
        Debug.Log(hp);
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

    public void Goal()
    {
        win = true;

        //points
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
            //points
        } else if (level == 2 && !win)
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
            //points 0
        }
        //points = p2
        hp = ogHp;

        //StartCoroutine(LateStart());
    }

    /*IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.01f);
        _player = GameObject.FindWithTag("Player");
    }*/
}
