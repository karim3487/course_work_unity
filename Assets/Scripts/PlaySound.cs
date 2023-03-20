using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip saw;
    void Start()
    {
        GetComponent<AudioSource> ().playOnAwake = false;
        GetComponent<AudioSource> ().clip = saw;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.gameObject.layer == 7)
        {
            GetComponent<AudioSource> ().Play ();
        }
    }
}
