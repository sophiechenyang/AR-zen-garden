using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CatToKoi : MonoBehaviour
{
    public ObserverBehaviour catTarget;
    public ObserverBehaviour fishTarget;

    bool catFish = false;
    bool catReturn = false;
    float speed = 0.03f;

    public GameObject cat;
    public GameObject fish;
    public GameObject catRotate;

    public TextMesh catX;
    public TextMesh catY;
    public TextMesh fishX;

    Animator m_catAnimate;

    void Start()
    {
        m_catAnimate = cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fishPos = fishTarget.transform.position;
        Vector3 catPos = catTarget.transform.position;
        Vector3 direction = fish.transform.position - cat.transform.position;
        Vector3 backToOriginDirection = catTarget.transform.position - cat.transform.position;
        catX.text = cat.transform.position.x.ToString();
        catY.text = cat.transform.position.y.ToString();
        fishX.text = fishTarget.transform.position.x.ToString();

        if (catTarget.TargetStatus.Status == Status.TRACKED && fishTarget.TargetStatus.Status == Status.TRACKED && !catFish)
        {
            catFish = true;
            catReturn = false;
        }

        if (catFish)
        {
            float tarDistance = Vector3.Distance(cat.transform.position, fishPos);
            Debug.Log(tarDistance);
            if (tarDistance > 0.01)
            {
                m_catAnimate.SetBool("isWalking", true);
                Quaternion rotation = Quaternion.LookRotation(direction);
                cat.transform.rotation = rotation;
                cat.transform.position = Vector3.MoveTowards(cat.transform.position, fishPos, Time.deltaTime * speed);
            } else if (tarDistance < 0.01)
            {
                m_catAnimate.SetBool("isWalking", false);
            }
        }

        float catToOriginDist = Vector3.Distance(cat.transform.position, catPos);
        if (catFish && (catTarget.TargetStatus.Status != Status.TRACKED || fishTarget.TargetStatus.Status != Status.TRACKED))
        {
            
            catFish = false;
            catReturn = true;
            
        }

        if (catReturn)
        {
            Debug.Log(catToOriginDist);
            if (catToOriginDist > 0.01)
            {
                Quaternion rotation = Quaternion.LookRotation(backToOriginDirection);
                cat.transform.rotation = rotation;
                cat.transform.position = Vector3.MoveTowards(cat.transform.position, catPos, Time.deltaTime * speed);
                m_catAnimate.SetBool("isWalking", true);
            }
            else if (catToOriginDist < 0.01)
            {
                m_catAnimate.SetBool("isWalking", false);
                //cat.transform.rotation = Quaternion.identity;
            }

        }

        //if (!catFish)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(fishToCatDirection);
        //    cat.transform.rotation = rotation;
        //    cat.transform.position = Vector3.MoveTowards(cat.transform.position, catPos, Time.deltaTime * speed);
        //}

        if (catFish && cat.transform.position == fishPos)
        {
            fish.SetActive(false);
        }
        else if (catFish && cat.transform.position != fishPos)
            fish.SetActive(true);
    }
}
