using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image p1;
    public Image p2;
    public Image p3;
    public Image p4;
    public Image p5;
    public Image p6;
    public Image p7;
    public Image p8;
    public Image p9;
    public Image p10;
    public Image p11;
    public Image p12;
    public Image p13;
    public Image p14;

    List<Image> imgs = new List<Image>();

    playerController i;
    void Start() { 
        i = GameObject.Find("Player").GetComponent<playerController>();
        imgs.Add(p1);
        imgs.Add(p2);
        imgs.Add(p3);
        imgs.Add(p4);
        imgs.Add(p5);
        imgs.Add(p6);
        imgs.Add(p7);
        imgs.Add(p8);
        imgs.Add(p9);
        imgs.Add(p10);
        imgs.Add(p11);
        imgs.Add(p12);
        imgs.Add(p13);
        imgs.Add(p14);
    }

    void Update()
    {
        int c = 0;
        foreach(KeyValuePair<int, item> k in i.inventory) {
            if (k.Value != null) {
                imgs[c]. = (k.Value.getSprite());
                c++;
            }
        }
    }
}
