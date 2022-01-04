using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlashLightCollectible : MonoBehaviour, ICollectibleItem
{
    private Light FlashLight;
    private bool IsPickedUp = false;
    private AudioSource audioSource;
    public event EventHandler PickUp;

    private void OnPickUpItem(EventArgs e)
    {
        EventHandler handler = PickUp;
        if (handler != null)
        {
            handler(this, e);
        }
        StartCoroutine(SetUpFlashlight());
    }
    
    void Start()
    {
        FlashLight = GameObject.Find("Spotlight").GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update ()
    {
        if (IsPickedUp)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                TriggerAction();
            }
        }
    }

    private IEnumerator SetUpFlashlight()
    {
        Vector3 destVector = new Vector3(0.3f, -0.2f, 0.5f);

        while (transform.localPosition != destVector)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destVector, Time.deltaTime * 15f);
            yield return null;
        }
    }

    public void SetUpItem()
    {
        transform.parent = Camera.main.transform;
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(new Vector3(0f, 0f, 0f));
        OnPickUpItem(EventArgs.Empty);
        IsPickedUp = true;
        gameObject.layer = 8;
    }

    public void TriggerAction()
    {
        FlashLight.enabled = !FlashLight.enabled;
        audioSource.Play();
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
