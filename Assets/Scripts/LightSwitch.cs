using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    GameObject[] Lights;
    public bool isOn;
    public AudioClip saw;


    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = saw;
        Lights = GameObject.FindGameObjectsWithTag("Light");
        Debug.Log(Lights);
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].GetComponent<Light>().enabled = isOn;
        }
    }

    public void Interact()
    {
        isOn = !isOn;
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].GetComponent<Light>().enabled = isOn;
        }
        GetComponent<AudioSource>().Play();
    }

    public string GetDescription()
    {
        if (isOn) return "Нажмите [E] чтобы <color=red>выключить</color> свет";
        return "Нажмите [E] чтобы <color=green>включить</color> свет";
    }
}