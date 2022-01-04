using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollectible : MonoBehaviour, ICollectibleItem {

    public event EventHandler PickUp;
    private bool IsSettingUp = false;
    private bool IsInspecting = false;
    private AudioSource audioSource;
    private Animator animator;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void SetUpItem()
    {
        transform.parent = Camera.main.transform;
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(new Vector3(95f, 110f, -70f));
        OnPickUpItem(EventArgs.Empty);
        gameObject.layer = 8;
        IsSettingUp = true;
    }

    public void Update()
    {
        if (IsSettingUp)
        {
            Vector3 destVector = new Vector3(0.3f, -0.2f, 0.5f);
            transform.localPosition = Vector3.Lerp(transform.localPosition, destVector, Time.deltaTime * 15f);
            if (transform.localPosition == destVector)
            {
                IsSettingUp = false;
                animator.enabled = true;
            }
        }
    }

    public void PutElement()
    {
        animator.enabled = false;
        transform.tag = "Untagged";
    }

    private void OnPickUpItem(EventArgs e)
    {
        EventHandler handler = PickUp;
        if (handler != null)
        {
            handler(this, e);
        }
        audioSource.Play();
    }

    public void TriggerAction()
    {
        IsInspecting = !IsInspecting;
        if (IsInspecting)
        {
            audioSource.Play();
        }
        animator.SetBool("IsInspecting", IsInspecting);

    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
        audioSource.Play();
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
