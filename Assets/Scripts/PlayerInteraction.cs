using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interationDistance = 10f;

    public GameObject ineractionUI;
    public TextMeshProUGUI interactionText;
    
    void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;
        
        if (Physics.Raycast(ray, out hit, interationDistance, 3))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        ineractionUI.SetActive(hitSomething);
    }

}
