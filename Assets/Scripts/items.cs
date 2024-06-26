using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// classes to access items
public class items : MonoBehaviour { 
    public item returnExample(){ return new example(); }
    public item returnApple(){ return new apple(); }
}


// item base class
public class item
{
    protected string name;
    protected int count = 0;
    protected int capacity;

    public string getName() { return name; }
    public int getCapacity() { return capacity; }
    public int getCount() { return count; }
}



// List of actual items
public class example : item { 
    public example() {
        name = "example";
        count = 1;
        capacity = 5;
    }
}

public class apple : item {
    public apple() {
        name = "Apple";
        count = 1;
        capacity = 10;
    }
}