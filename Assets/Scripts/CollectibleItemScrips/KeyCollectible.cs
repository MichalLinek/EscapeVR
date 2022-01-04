using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyCollectible : MonoBehaviour, ICollectibleItem {

    public event EventHandler PickUp;
    private Animator animator;
    private AudioSource audioSource;

    private void OnPickUpItem(EventArgs e)
    {
        EventHandler handler = PickUp;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetUpItem()
    {
        transform.parent = Camera.main.transform;
        transform.rotation = Camera.main.transform.rotation;
        transform.Rotate(new Vector3(0, -80f, 0f));
        OnPickUpItem(EventArgs.Empty);
        gameObject.layer = 8;
        animator.SetBool("IsPickedUp", true);
        StartCoroutine(SetUpKey());
    }

    private IEnumerator SetUpKey()
    {
        Vector3 destVector = new Vector3(0.3f, -0.2f, 0.5f);

        while (transform.localPosition != destVector)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, destVector, Time.deltaTime * 15f);
            yield return null;
        }
        animator.enabled = true;
    }
    
    public void TriggerAction()
    {
        animator.SetBool("IsTriggered", true);
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("keyOpen"))
        {
            animator.SetBool("IsTriggered", false);
        }
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
