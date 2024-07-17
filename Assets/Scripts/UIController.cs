using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Image p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14;
    public TextMeshProUGUI t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14;

    List<Image> imgs = new List<Image>();
    List<TextMeshProUGUI> txts = new List<TextMeshProUGUI>();

    playerController i;
    void Start()
    {
        i = GameObject.Find("Player").GetComponent<playerController>();

        p1 = GameObject.Find("i1").GetComponent<Image>();     imgs.Add(p1);
        p2 = GameObject.Find("i2").GetComponent<Image>();     imgs.Add(p2);
        p3 = GameObject.Find("i3").GetComponent<Image>();     imgs.Add(p3);
        p4 = GameObject.Find("i4").GetComponent<Image>();     imgs.Add(p4);
        p5 = GameObject.Find("i5").GetComponent<Image>();     imgs.Add(p5);
        p6 = GameObject.Find("i6").GetComponent<Image>();     imgs.Add(p6);
        p7 = GameObject.Find("i7").GetComponent<Image>();     imgs.Add(p7);
        p8 = GameObject.Find("i8").GetComponent<Image>();     imgs.Add(p8);
        p9 = GameObject.Find("i9").GetComponent<Image>();     imgs.Add(p9);
        p10 = GameObject.Find("i10").GetComponent<Image>();   imgs.Add(p10);
        p11 = GameObject.Find("i11").GetComponent<Image>();   imgs.Add(p11);
        p12 = GameObject.Find("i12").GetComponent<Image>();   imgs.Add(p12);
        p13 = GameObject.Find("i13").GetComponent<Image>();   imgs.Add(p13);
        p14 = GameObject.Find("i14").GetComponent<Image>();   imgs.Add(p14);

        t1 = GameObject.Find("t1").GetComponent<TextMeshProUGUI>();     txts.Add(t1);
        t2 = GameObject.Find("t2").GetComponent<TextMeshProUGUI>();     txts.Add(t2);
        t3 = GameObject.Find("t3").GetComponent<TextMeshProUGUI>();     txts.Add(t3);
        t4 = GameObject.Find("t4").GetComponent<TextMeshProUGUI>();     txts.Add(t4);
        t5 = GameObject.Find("t5").GetComponent<TextMeshProUGUI >();     txts.Add(t5);
        t6 = GameObject.Find("t6").GetComponent<TextMeshProUGUI>();     txts.Add(t6);
        t7 = GameObject.Find("t7").GetComponent<TextMeshProUGUI>();     txts.Add(t7);
        t8 = GameObject.Find("t8").GetComponent<TextMeshProUGUI>();     txts.Add(t8);
        t9 = GameObject.Find("t9").GetComponent<TextMeshProUGUI>();     txts.Add(t9);
        t10 = GameObject.Find("t10").GetComponent<TextMeshProUGUI>();   txts.Add(t10);
        t11 = GameObject.Find("t11").GetComponent<TextMeshProUGUI>();   txts.Add(t11); 
        t12 = GameObject.Find("t12").GetComponent<TextMeshProUGUI>();   txts.Add(t12);
        t13 = GameObject.Find("t13").GetComponent<TextMeshProUGUI>();   txts.Add(t13);
        t14 = GameObject.Find("t14").GetComponent<TextMeshProUGUI   >();   txts.Add(t14);


    }
    void Update()
    {
        int c = 0;
        foreach(KeyValuePair<int, item> k in i.inventory) {
            if (k.Value != null) {
                imgs[c].sprite = k.Value.getSprite();
                txts[c].text = (k.Value.getCount()).ToString();
                c++;
            }
        }
    }
}
