using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject Player;
    float offset;


    void Start()
    {
        offset = transform.position.x - Player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
