using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportObject : MonoBehaviour {

    public GameObject Carrier;
    public Vector3 Offset;

    private bool IsPickedUp;
    private ICollectibleItem item;

    void Start () {
        item = GetComponent<ICollectibleItem>();
        item.PickUp += Item_PickUp;
	}

    void OnDestroy()
    {
        item.PickUp -= Item_PickUp;
    }

    private void Item_PickUp(object sender, System.EventArgs e)
    {
        IsPickedUp = true;
    }

    void Update()
    {
        if (!IsPickedUp)
        {
            transform.position = Carrier.transform.position + Offset;
        }
    }
}
