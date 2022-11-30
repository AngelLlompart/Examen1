using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnQuit;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        btnPlay.onClick.AddListener(Play);
        btnOptions.onClick.AddListener(Options);
        btnQuit.onClick.AddListener(Quit);
        StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Play()
    {
        _gameManager.level = 1;
        SceneManager.LoadScene("Level 1");
    }

    private void Options()
    {
        
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
