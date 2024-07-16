using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// classes to access items
public class items : MonoBehaviour {

    // public IDictionary<int, item> list = new Dictionary<int, item>();
    public IDictionary<string, item> index = new Dictionary<string, item>();

    void Start(){
        index.Add("Apple", new apple());
        index.Add("Monster Horns", new horns());
    }
}


// item base class
public class item
{
    protected string name;
    protected int count = 0;
    protected int capacity;

    public string getName()  { return name; }
    public int getCapacity() { return capacity; }
    public int getCount()    { return count; }
}



// List of actual items
public class apple : item {
    public apple() {
        name = "Apple";
        capacity = 10;
    }
}

public class horns : item { 
    public horns() {
        name = "Monster Horns";
        capacity = 3;
    }
}
