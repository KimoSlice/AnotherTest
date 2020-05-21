using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour
{
    Rigidbody rb;
    public int boxId;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    public void SetPickedUpState(Transform holder)
    {
        rb.useGravity = false; //Stopps Box from fall
        rb.isKinematic = true; //Stops Box interacting with other objects
        transform.parent = holder;
    }

    public void SetDroppedState()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
    }

    public int ReturnBoxId()
    {
        return boxId;
    }
}
