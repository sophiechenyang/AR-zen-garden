using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToMove : MonoBehaviour
{
    public GameObject foodPrefab;
    GameObject flower;
    public Vector3 goalPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000.0f)){
                Debug.Log("ray casted");
                goalPos = hit.point;
                flower = Instantiate(foodPrefab, goalPos, Quaternion.identity);
                Invoke("RemoveFlower", 3.0f);
            }

        }
    }

    void RemoveFlower()
    {
        Destroy(flower);
    }
}
