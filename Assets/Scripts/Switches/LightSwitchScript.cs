using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchScript : MonoBehaviour {
    
    private Light RoomLight;
    private Light Backlighting;
    public List<GameObject> hiddenNumbers;
    private Quaternion rotation;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        RoomLight = GameObject.Find("RoomLight").GetComponent<Light>();
        Backlighting = GameObject.Find("BackLighting").GetComponent<Light>();
        rotation = transform.localRotation;
    }

    private void Toggle()
    {
        RoomLight.enabled = !RoomLight.enabled;
        Backlighting.enabled = !Backlighting.enabled;
        
        foreach(GameObject gObject in hiddenNumbers)
        {
            gObject.SetActive(!gObject.activeSelf);
        }

        audioSource.Play();
        if (RoomLight.enabled)
        {
            transform.localRotation = rotation;
        }
        else
        {
            Vector3 vector = transform.localRotation.eulerAngles;
            transform.localRotation = Quaternion.Euler(new Vector3(-180,90,-90));
        }
    }
}
