using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] int ThrownObjectsLayer = 3;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == ThrownObjectsLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
