using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    
    private float radius =13.8461538f;
    
    public void Toggle()
    {
        var relativePoint = Camera.main.transform.InverseTransformPoint(transform.position);
        Vector3 vector = new Vector3();

        if (relativePoint.x < 0.0)
        {
            vector = this.transform.eulerAngles + new Vector3(0.0f, radius, 0.0f);
        }
        else if (relativePoint.x > 0.0)
        {
            vector = this.transform.eulerAngles + new Vector3(0.0f, -radius, 0.0f);
        }
        
        //vector.y = vector.y % 360;  
        this.transform.eulerAngles = vector;
    }
}
