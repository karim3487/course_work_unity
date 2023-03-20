using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour, IInteractable
{   
    public GameObject FigurePrefab;
    public GameObject Spawner;
    public AudioClip saw;
    public float DelayBeforeSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = saw;
    }
    
    IEnumerator playSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(saw, 0.3f);
    }

    public void Interact()
    {
        var inst = Instantiate(FigurePrefab, Spawner.transform.position, Quaternion.identity);
        inst.SetActive(true);
        StartCoroutine(playSoundWithDelay(DelayBeforeSound));
    }

    public string GetDescription()
    {
        return "Нажмите [E] чтобы появилась фигура";
    }
}
