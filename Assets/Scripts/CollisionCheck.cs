using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public GameObject m_guide, m_sphere;
    public Collider collider_1, collider_2;
    public bool colliding;

    void Start()
    {
        colliding = false;
        updateGuide();
    }

    void Update()
    {
        bool prevColliding = colliding;
        colliding = collider_1.bounds.Intersects(collider_2.bounds);
        if (prevColliding == colliding) return;
        updateGuide();

    }

    void updateGuide()
    {
        m_guide.SetActive(!colliding);
        m_sphere.SetActive(colliding);
    }


    public bool IsColliding()
    {
        return colliding;
    }
}
