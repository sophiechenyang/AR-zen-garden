using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public List<CollisionCheck> CollisionCheckers = new List<CollisionCheck>();
    public GameObject Tori;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool allColliding = true;

        foreach(var checker in CollisionCheckers)
        {
            if (!checker.IsColliding())
            {
                allColliding = false;
                break;
            }
        }

        if (allColliding)
        {
            Tori.SetActive(true);
        } else
        {
            Tori.SetActive(false);
        }

    }
}
