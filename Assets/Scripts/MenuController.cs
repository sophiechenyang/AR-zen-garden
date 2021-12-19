using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MenuController : MonoBehaviour
{
    public GameObject cubeGO, sphereGO;
    VirtualButtonBehaviour vrb;

    void Start()
    {
        cubeGO.SetActive(false);
        sphereGO.SetActive(true);

        vrb = GetComponentInChildren<VirtualButtonBehaviour>();

        vrb.RegisterOnButtonPressed(onButtonPressed);
        vrb.RegisterOnButtonReleased(onButtonReleased);
    }

    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        cubeGO.SetActive(true);
        sphereGO.SetActive(false);
    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        cubeGO.SetActive(false);
        sphereGO.SetActive(true);
    }
}
