using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CalculateDistance : MonoBehaviour
{
    public ObserverBehaviour targetOne;
    public ObserverBehaviour targetTwo;
    public TextMesh count;
    public TextMesh targetOneX;
    public TextMesh targetTwoX;
    public GameObject cylinder;

    bool hasTwoObjects = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetOne.TargetStatus.Status == Status.TRACKED && targetTwo.TargetStatus.Status == Status.TRACKED && !hasTwoObjects)
        {
            hasTwoObjects = true;
        }

        if (hasTwoObjects)
        {
            float tarDistance = Vector3.Distance(targetOne.transform.position, targetTwo.transform.position);
            Debug.Log(tarDistance);
            count.text = tarDistance.ToString();
            targetOneX.text = targetOne.transform.position.x.ToString();
            targetTwoX.text = targetTwo.transform.position.x.ToString();

            if(targetOne.transform.position.x > targetTwo.transform.position.x)
            {
                if (tarDistance < 0.06f)
                    cylinder.SetActive(true);
                else if (tarDistance > 0.06f)
                    cylinder.SetActive(false);
            } else
            {
                cylinder.SetActive(false);
            }
        }
    }

}
