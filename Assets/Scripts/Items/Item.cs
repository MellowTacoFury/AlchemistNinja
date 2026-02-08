using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_SO item;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Hand h = other.gameObject.GetComponent<Hand>();
            Smack(h.direction, h.transform.position, h.smackForce);
        }
    }

    private void Smack(Vector3 direction, Vector3 position, float force)
    {
        Debug.Log("Shmacked");
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,angle);

        gameObject.GetComponent<Rigidbody>().AddForceAtPosition(direction*force, position, ForceMode.Impulse);

    }
}
