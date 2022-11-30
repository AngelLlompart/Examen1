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

    private bool win = false;

    private GameObject _player;

    [SerializeField] private TextMeshProUGUI txtWin;

    [SerializeField] private Button btnReiniciar;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        txtWin.gameObject.SetActive(false);
        btnReiniciar.gameObject.SetActive(false);
        btnReiniciar.onClick.AddListener(GameOver);
        Time.timeScale = 1.0f;
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
            EndLevel("You died!");
            
        }
        else
        {
            _player.transform.rotation = Quaternion.identity;
            _player.transform.position = Vector3.zero;
        }
    }

    private void EndLevel(string message)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        txtWin.text = message;
        txtWin.gameObject.SetActive(true);
        btnReiniciar.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Level 1");
    }
}
