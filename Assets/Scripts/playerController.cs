using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput inp;
    Animator ani;

    Vector2 dir;
    float speed = 4;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        inp = GetComponent<PlayerInput>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dir = inp.actions.FindAction("Movement").ReadValue<Vector2>();
        ani.SetFloat("x", dir.x);
        ani.SetFloat("y", dir.y);

        rb.AddForce(new Vector3(dir.x, 0, dir.y * 2) * speed);
    }
}
