using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideChecker : MonoBehaviour
{
    private bool colliding;
    public bool Colliding
    {
        get
        {
            return colliding;
        }
    }

    private void Update()
    {
        //Debug.Log(transform.gameObject.name + " " + colliding);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.gameObject.name + " ColliderEnter");
        colliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(transform.gameObject.name + " ColliderExit");
        colliding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.gameObject.name + " TriggerEnter");
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(transform.gameObject.name + " TriggerExit");
        colliding = false;
    }
}
