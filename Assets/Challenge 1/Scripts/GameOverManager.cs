using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnQuit;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        btnRestart.onClick.AddListener(Restart);
        btnMenu.onClick.AddListener(Menu);
        btnQuit.onClick.AddListener(Quit);
        StartCoroutine(LateStart());
    }

    private void Restart()
    {
        if (_gameManager.level == 1)
        { 
            SceneManager.LoadScene("Level 1");
        }
        else
        {
            SceneManager.LoadScene("Level 2");
        }
    }
    
    private void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Quit()
    {
        #if UNITY_EDITOR
            if(EditorApplication.isPlaying) 
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        #else
            Application.Quit();
        #endif
    }
    
    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
