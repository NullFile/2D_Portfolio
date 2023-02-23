using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private bool isMovement;

    private float speed;
    private Vector3 vec;

    void Start()
    {
        speed = Random.Range(0.5f, 1.25f);
    }

    void Update()
    {
        if (isMovement == false)
            return;

        if (13.5f < transform.position.x)
        {
            Random_Speed();

            vec = transform.position;
            vec.x = -13.5f;
            vec.y = Random.Range(-1.0f, 4.5f);
            vec.z = vec.y;

            transform.position = vec;
        }

        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void Random_Speed()
    {
        speed = Random.Range(0.5f, 1.25f);
    }
}
