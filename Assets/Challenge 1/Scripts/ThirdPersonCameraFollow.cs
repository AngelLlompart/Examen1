using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraFollow : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(0,2,-15);

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
