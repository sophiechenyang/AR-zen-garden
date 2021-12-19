using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    float speed = 0.5f;
    float rotationSpeed = 50.0f;
    protected Joystick joystick;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType< Joystick>();
    }

    void Update()
    {

        float translation = joystick.Vertical * speed;
        float rotation = joystick.Horizontal * rotationSpeed;
        //float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation > 0)
        {
            anim.SetBool("isWalking", true);
            //anim.SetFloat("speed", 1.0f);
        } else if (translation < 0){
            anim.SetBool("isWalking", true);
            //anim.SetFloat("speed", -1.0f);
        } else {
            anim.SetBool("isWalking", false);
        }
    }
}
