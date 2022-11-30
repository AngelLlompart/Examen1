using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWithGravity : MonoBehaviour
{
    private Rigidbody _playerRb;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _playerRb.velocity += (transform.up * 80 * Time.deltaTime);
        }
        
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 15);
    }
}
