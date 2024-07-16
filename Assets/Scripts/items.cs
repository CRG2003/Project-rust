using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


// classes to access items
public class items : MonoBehaviour {

    // list of classes used for adding items to inventory 
    public IDictionary<string, item> index = new Dictionary<string, item>();

    void Start(){
        index.Add("Apple", new apple());
        index.Add("Monster Horns", new horns());
        index.Add("Potato", new potato());
    }
}


// item base class
public class item
{
    protected string name;
    protected int count = 1;
    protected int capacity;
    public Sprite img;

    public string getName()   { return name; }
    public int getCapacity()  { return capacity; }
    public int getCount()     { return count; }
    public Sprite getSprite() { return img; }
    public void incriment()   { count++; }

}



// List of actual items
public class apple : item {
    public apple() {
        name = "Apple";
        capacity = 10;
        count = 1;
        img = Resources.Load<Sprite>("Assets/Items/Images/SApple");
    }
}

public class horns : item { 
    public horns() {
        name = "Monster Horns";
        capacity = 3;
        count = 1;
    }
}

public class potato : item {
    public potato() {
        name = "Potato";
        capacity = 10;
        count = 1;
        img = Resources.Load<Sprite>("Assets/Items/Images/SPotato");
    }
}

