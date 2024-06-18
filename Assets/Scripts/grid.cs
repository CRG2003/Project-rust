using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    IDictionary<Vector2, string> points = new Dictionary<Vector2, string>();

    public GameObject plot;

    public bool createPlot(Vector2 pos, string type){
        if (points.ContainsKey(pos)){
            return false;
        }
        else{
            points.Add(pos, type);
            Instantiate(plot, new Vector3(pos.x, 0, pos.y), Quaternion.identity);
            return true;
        }
    }
}