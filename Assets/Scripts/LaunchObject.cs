using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] float seconds = 1.5f;
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    //     StartCoroutine(PushObject(seconds));
    // }
    // IEnumerator PushObject(float seconds)
    // {
    //     yield return new WaitForSeconds(seconds);
    //     rb.AddForce(Vector3.up*10, ForceMode.Impulse);
    // }
}
