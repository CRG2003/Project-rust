using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public ParticleSystem collect;

    // Player variables 
    Vector2 dir;
    float speed = 6;
    int health = 10;


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


    // Fixed update for physics based movement controls
    void FixedUpdate() {

        // Player inputs
        dir = inp.actions.FindAction("Movement").ReadValue<Vector2>();
        ani.SetFloat("x", dir.x);
        ani.SetFloat("y", dir.y);

        rb.AddForce(new Vector3(dir.x, 0, dir.y * 1.5f) * speed);
    }


    // Update for other user inputs (e.g. interactions)
    void Update() {
        int a = (int)(rb.transform.position.x) / 3;
        int b = (int)(rb.transform.position.z) / 3;

        orb.transform.position = new Vector3(a * 3, 0, b * 3);

        if (inp.actions.FindAction("e").WasPressedThisFrame()) {
            gri.createPlot(new Vector2(a * 3, b * 3), "field");
        }

        if (inp.actions.FindAction("q").WasPressedThisFrame()) {
            health--;
        }
    }


    public bool check;
    public int pos;
    void OnTriggerEnter(Collider hit) {

        if (it.index.ContainsKey(hit.name)) {

            // checks if item is already in inventory 
            check = false;
            pos = 0;
            foreach(KeyValuePair<int, item> k in inventory) {
                if (k.Value != null) {
                    if (k.Value.getName() == it.index[hit.name].getName() && k.Value.getCount() != k.Value.getCapacity()) {
                        check = true;
                        pos = k.Key;
                    }
                }
            }

            // incriments existing item count
            if (check) { inventory[pos].incriment(); }


            // adding new item to first empty slot
            else{
                for (int i = 0; i < inventory.Count; i++) {
                    if (inventory[i] == null) {
                        inventory[i] = it.index[hit.name].CloneViaSerialization();
                        break;
                    }
                }
            }
            ParticleSystem g = Instantiate(collect, t.transform);
            g.transform.position = hit.transform.position;
            Destroy(hit.gameObject);

        }
    }

    public int getHealth()
    {
        return health;  
    }
}
