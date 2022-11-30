using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int hp = 3;

    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        hp--;
        if (hp <= 0)
        {
            EndLevel("You died!");
        }
    }

    private void EndLevel(string message)
    {
        
    }
}
