using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCreated : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += new Vector3(0, speed, 0);
    }
}
