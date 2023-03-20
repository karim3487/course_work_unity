using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public Camera Camera;
    void Start()
    {
        
    }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit, 300, 3))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);
            
            Vector3 directionWithoutSpread = targetPoint - bulletSpawnPoint.position;

            float x = Random.Range(-1, 1);
            float y = Random.Range(-1, 1);

            Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

            GameObject currentBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity); //store instantiated bullet in currentBullet
            currentBullet.transform.forward = directionWithSpread.normalized;

            currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * 30, ForceMode.Impulse);
            currentBullet.GetComponent<Rigidbody>().AddForce(Camera.transform.up * 0, ForceMode.Impulse);
        }
        Ray ray1 = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit1;
        Vector3 targetPoint1;
        if (Physics.Raycast(ray1, out hit1, 300, 3))
            targetPoint1 = hit1.point;
        else
            targetPoint1 = ray1.GetPoint(75);
        
        Debug.DrawRay(transform.position, targetPoint1, Color.green);

    }
}
