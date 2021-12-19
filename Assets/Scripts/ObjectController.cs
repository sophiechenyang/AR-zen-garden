using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectController : MonoBehaviour
{
    public ObserverBehaviour toriTarget;
    public ObserverBehaviour sakuraTarget;
    public ObserverBehaviour pineTarget, mapleTarget;
    public ObserverBehaviour waterfallTarget;
    public GameObject sakura, tree, maple, waterfall, pond;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toriTarget.TargetStatus.Status == Status.TRACKED && sakuraTarget.TargetStatus.Status == Status.TRACKED)
        {
            sakura.SetActive(true);
        }

        if (sakuraTarget.TargetStatus.Status != Status.TRACKED)
        {
            sakura.SetActive(false);
        }

        if (toriTarget.TargetStatus.Status == Status.TRACKED && pineTarget.TargetStatus.Status == Status.TRACKED)
        {
            tree.SetActive(true);
        }

        if (pineTarget.TargetStatus.Status != Status.TRACKED)
        {
            tree.SetActive(false);
        }

        if (toriTarget.TargetStatus.Status == Status.TRACKED && mapleTarget.TargetStatus.Status == Status.TRACKED)
        {
            maple.SetActive(true);
        }

        if (mapleTarget.TargetStatus.Status != Status.TRACKED)
        {
            maple.SetActive(false);
        }

        if (waterfallTarget.TargetStatus.Status == Status.TRACKED && toriTarget.TargetStatus.Status == Status.TRACKED)
        {
            waterfall.SetActive(true);
            pond.SetActive(true);
        }

        if (waterfallTarget.TargetStatus.Status != Status.TRACKED)
        {
            waterfall.SetActive(false);
            pond.SetActive(false);
        }
    }
}
