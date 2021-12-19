using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonChecker : MonoBehaviour
{
    public ObserverBehaviour target;
    public GameObject moveBtton;
    public GameObject stopBttn;
    CollisionCheck collisionCheck;
    void Start()
    {
        collisionCheck = target.GetComponent<CollisionCheck>();
    }

    void Update()
    {
        if (target.TargetStatus.Status == Status.TRACKED && collisionCheck.colliding != true)
        {
            moveBtton.SetActive(true);
            stopBttn.SetActive(true);
        } else {
            moveBtton.SetActive(false);
            stopBttn.SetActive(false);
        }
    }
}
