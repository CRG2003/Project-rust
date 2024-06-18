using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public GameObject orb;

    Rigidbody rb;
    PlayerInput inp;
    Animator ani;

    Vector2 dir;
    float speed = 6;

    grid scr;

    //IDictionary<int, >

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        inp = GetComponent<PlayerInput>();
        ani = GetComponent<Animator>();

        scr = GetComponent<grid>();
    }


    void FixedUpdate()
    {
        dir = inp.actions.FindAction("Movement").ReadValue<Vector2>();
        ani.SetFloat("x", dir.x);
        ani.SetFloat("y", dir.y);

        rb.AddForce(new Vector3(dir.x, 0, dir.y * 1.5f) * speed);

        int a = (int)(rb.transform.position.x) / 3;
        int b = (int)(rb.transform.position.z) / 3;

        orb.transform.position = new Vector3(a*3, 0, b*3);

        if (inp.actions.FindAction("e").ReadValue<float>() > 0){          
            scr.createPlot(new Vector2(a*3, b*3), "field");
        }
    }
}
