using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    // Players components
    public GameObject orb;

    Rigidbody rb;
    PlayerInput inp;
    Animator ani;

    GameObject t;
    grid gri;
    items it;

    // Player variables 
    Vector2 dir;
    float speed = 6;

    public IDictionary<item, int> inventory = new Dictionary<item, int>();



    void Start() {

        rb = transform.GetComponent<Rigidbody>();
        inp = GetComponent<PlayerInput>();
        ani = GetComponent<Animator>();

        t = GameObject.Find("Things");
        gri = t.GetComponent<grid>();
        it = t.GetComponent<items>();   
    }


    void FixedUpdate() {

        // Player inputs
        dir = inp.actions.FindAction("Movement").ReadValue<Vector2>();
        ani.SetFloat("x", dir.x);
        ani.SetFloat("y", dir.y);

        rb.AddForce(new Vector3(dir.x, 0, dir.y * 1.5f) * speed);

        int a = (int)(rb.transform.position.x) / 3;
        int b = (int)(rb.transform.position.z) / 3;

        orb.transform.position = new Vector3(a * 3, 0, b * 3);

        if (inp.actions.FindAction("e").ReadValue<float>() > 0) {
            gri.createPlot(new Vector2(a * 3, b * 3), "field");
        }

        if (inp.actions.FindAction("q").ReadValue<float>() > 0) {
            inventory.Add(it.returnExample(), 1);
        }


        // debugging
        int i = 0;
        foreach (KeyValuePair<item, int> k in inventory) {
            i++;
            Debug.Log(i + ": " + k.Key.getName() + " - " + k.Key.getCount());
        }

    }
    void OnTriggerEnter(Collider hit) {
        if (hit.CompareTag("apple")) {
            if (inventory.ContainsKey(it.returnApple())){
                inventory[it.returnApple()]++;
            }
            else {
                inventory.Add(it.returnApple(), 1);
            }
            Destroy(hit.gameObject);
        }
    }
}
