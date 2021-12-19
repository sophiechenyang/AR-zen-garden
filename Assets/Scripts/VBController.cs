using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBController : MonoBehaviour
{

    public GameObject cube, capsule;
    VirtualButtonBehaviour[] vrb;
    GameManager gameManager;
    ObserverBehaviour mObserverBehaviour;

    void Start()
    {
        //cube.SetActive(true);
        //capsule.SetActive(true);
        vrb = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i< vrb.Length; i++)
        {
            vrb[i].RegisterOnButtonPressed(onButtonPressed);
            vrb[i].RegisterOnButtonReleased(onButtonReleased);
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mObserverBehaviour = GetComponent<ObserverBehaviour>();

    }

    void Update()
    {
    }

    void onButtonPressed(VirtualButtonBehaviour vb)
    {
        if(vb.VirtualButtonName == "OneVB")
        {
            cube.SetActive(true);
            capsule.SetActive(false);
        } else if (vb.VirtualButtonName == "TwoVB")
        {
            cube.SetActive(false);
            capsule.SetActive(true);
        } else
        {
            throw new UnityException(vb.VirtualButtonName + "virtual button not supported");
        }
        
    }

    void onButtonReleased(VirtualButtonBehaviour vb)
    {
        capsule.SetActive(false);
        cube.SetActive(false);
        Debug.Log("Button Released");

    }
}
