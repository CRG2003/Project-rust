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

    // public IDictionary<item, int> inventory = new Dictionary<item, int>();
    public IDictionary<int, item> inventory = new Dictionary<int, item>();


    void Start() {

        for (int i = 0; i < 10; i++) {
            inventory.Add(i, null);
        }

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

        string s = "";
        foreach(KeyValuePair<int, item> k in inventory) {
            if (k.Value != null) {
                s += k.Value.getName() + " / ";
            }
        }
        Debug.Log(s);

    }

    void OnTriggerEnter(Collider hit) {
        if (it.index.ContainsKey(hit.name)) {
            for (int i = 0; i < inventory.Count; i++) { 
                if (inventory[i] == null){
                    inventory[i] = it.index[hit.name];
                    Destroy(hit.gameObject);
                    break;
                }
            }
        }
    }
}
