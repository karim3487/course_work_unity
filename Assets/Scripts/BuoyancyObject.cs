using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public float floatUpSpeedLimit = 1.15f;
    public float floatUpSpeed = 1f;
    
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            float difference = (other.transform.position.y - transform.position.y) * floatUpSpeed;
            m_Rigidbody.AddForce(new Vector3(0f, Mathf.Clamp((Mathf.Abs(Physics.gravity.y) * difference), 0, Mathf.Abs(Physics.gravity.y) * floatUpSpeedLimit), 0f), ForceMode.Acceleration);
            m_Rigidbody.drag = 0.99f;
            m_Rigidbody.angularDrag = 0.8f;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            m_Rigidbody.drag = 0f;
            m_Rigidbody.angularDrag = 0f;

        }
    }
}