using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameManager : MonoBehaviour
{
    bool pondFish = false;

    public Vector3 pondPos;
    public Vector3 fishPos;

    //public List<ObserverBehaviour> trackedObjectList = new List<ObserverBehaviour>();
    public ObserverBehaviour pondTarget;
    public ObserverBehaviour fishTarget;
    //public DefaultObserverEventHandler pond;
    public GameObject fish;
    public GameObject movingFish1;
    public AudioSource bgMusic;
    public GameObject carrot;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pondPos = pondTarget.transform.position;
        fishPos = fishTarget.transform.position;

        //Debug.Log(pondPos);

        if (pondTarget.TargetStatus.Status == Status.TRACKED && fishTarget.TargetStatus.Status == Status.TRACKED && !pondFish)
        {
            pondFish = true;
            movingFish1.SetActive(true);
            fish.SetActive(false);
            showPondFish();

        }
        else if (fishTarget.TargetStatus.Status != Status.TRACKED)
        {
            movingFish1.SetActive(false);
        }
        else if (pondTarget.TargetStatus.Status != Status.TRACKED)
        {
            if (pondFish)
            {
                fish.SetActive(true);
            }
            movingFish1.SetActive(false);
        }

        if (pondFish && (pondTarget.TargetStatus.Status != Status.TRACKED || fishTarget.TargetStatus.Status != Status.TRACKED))
        {
            pondFish = false;
            hidePondFish();
        }

        //if (pondFish)
        //{
        //    float tarDistance = Vector3.Distance(pondPos, fishPos);
        //    Debug.Log(tarDistance);
        //    if (tarDistance < 0.001f)

        //        Debug.Log("Yay");
        //        carrot.SetActive(true);
        //}

    }

    void showPondFish()
    {
        bgMusic.Play();
    }

    void hidePondFish()
    {
        bgMusic.Pause();
        carrot.SetActive(false);
    }
}
