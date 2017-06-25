using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_MovingPlatform : MonoBehaviour {

    private Vector3 startPosition;

    private Vector3 newPosition;


    [SerializeField]
    public int speed = 1;

    [SerializeField]
    public int maxDistance = 2;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = newPosition;
    }
}
