using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveGateSc : MonoBehaviour
{
    public GameObject removeEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            Instantiate(removeEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
