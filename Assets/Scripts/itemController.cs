using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public string Name;

    GameObject cam;
    void Start()
    {
        this.name = Name;
        cam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        transform.LookAt(cam.transform.position);
    }
}
