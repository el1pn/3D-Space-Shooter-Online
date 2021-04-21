using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shoot : MonoBehaviour
{
    private Vector3 destination;
    public GameObject projectile;
    public Transform LHFirePoint, RHFirePoint;
    private bool leftHand;
    public float projectileSpeed = 300;

    public float fireRate = 4;
    public float timeToFire;
    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        if (Input.GetButton("Fire1")&&Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }

    public void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            destination = hit.point;
        else destination = ray.GetPoint(1000);
        if(leftHand)
        {
            leftHand = false;
            InstantiateProjectile(LHFirePoint);
        }
        else
        {
            leftHand = true;
            InstantiateProjectile(RHFirePoint);
        }
    }
    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
