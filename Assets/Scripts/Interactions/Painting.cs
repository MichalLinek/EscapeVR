using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour {

    public Vector3 Position;
    public Quaternion Rotation;

    private AudioSource audioSource;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private bool putDown = false;

	void Start () {
        StartPosition = transform.position;
        StartRotation = transform.rotation;
        audioSource = GetComponent<AudioSource>();
    }

    public void TogglePainting()
    {
        if (putDown)
        {
            this.transform.position = StartPosition;
            this.transform.rotation = StartRotation;
        }
        else
        {
            this.transform.position = Position;
            this.transform.rotation = Rotation;
            audioSource.Play();
        }

        putDown = !putDown;
    }
}
