using UnityEngine;
using System.Collections;

public class HiddenText : MonoBehaviour {

    Transform tfLight;
    Renderer myRenderer;
 
    void Start()
    {
        // find the revealing light named "RevealingLight":
        var goLight = GameObject.Find("Spotlight");
        if (goLight) tfLight = goLight.transform;
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (tfLight)
        {
            myRenderer.material.SetVector("_LightPos", tfLight.position);
            myRenderer.material.SetVector("_LightDir", tfLight.forward);
        }
    }
}
