using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AnimateTile : MonoBehaviour
{
    Vector3 newPos;
    Vector3 oldPos;

    public GameObject tiles;
    public GameObject destination;
    public GameObject origin;

    float speed = 0.01f;
    public float moveFraction = 0;

    void Start()
    {
        moveFraction = 0;
        Debug.Log("start");
    }

    void Update()
    {
        MoveTile();
    }

    public void MoveTile()
    {
        moveFraction += Time.deltaTime * speed;
        if (moveFraction > 0.045)
        {
            moveFraction = 0;
        }
        newPos = destination.transform.position;
        oldPos = origin.transform.position;
        tiles.transform.position = Vector3.MoveTowards(oldPos, newPos, moveFraction);
    }
}
