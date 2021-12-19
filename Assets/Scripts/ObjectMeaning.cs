using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectMeaning : MonoBehaviour
{
    public ObserverBehaviour objectTarget;
    public ObserverBehaviour meaningTarget;

    public GameObject pronounciation;
    public GameObject meaning;
    public GameObject objectStatic;
    public GameObject objectRotate;
    public AudioSource pAudio;

    bool showMeaning = false;

    void Start()
    {

    }

    void Update()
    {
        if (objectTarget.TargetStatus.Status == Status.TRACKED && meaningTarget.TargetStatus.Status == Status.TRACKED && !showMeaning)
        {
            pronounciation.SetActive(true);
            meaning.SetActive(true);
            objectStatic.SetActive(false);
            objectRotate.SetActive(true);
            showMeaning = true;
            pAudio.Play();

        }

        

        if (meaningTarget.TargetStatus.Status != Status.TRACKED)
        {
            if (showMeaning)
            {
                objectStatic.SetActive(true);
            }
            objectRotate.SetActive(false);
            pronounciation.SetActive(false);
            meaning.SetActive(false);
            showMeaning = false;
        }

    }
}

