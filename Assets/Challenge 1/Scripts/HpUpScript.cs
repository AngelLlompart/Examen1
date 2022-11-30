using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpScript : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private GameObject[] _gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject == _gameObjects[0])
            {
                Debug.Log("SS");
                _gameManager.HpUp(1);
            } else if (gameObject == _gameObjects[1])
            {
                Debug.Log("EE");
                _gameManager.HpUp(2);
            }
            Destroy(gameObject);
        }
    }
}
