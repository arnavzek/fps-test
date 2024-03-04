using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;
    public Transform gunOrientation;


    private Rigidbody rb;
    public float movementSpeed;

    public Transform instancePosition;

    public float bulletSpeed;
    public GameObject bulletPrefab;

    private bool shouldShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        StartCoroutine(ShootInterval());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shouldShoot = true;
        }
        else
        {
            shouldShoot = false;
        }
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 direction = orientation.forward * Input.GetAxis("Vertical") + orientation.right * Input.GetAxis("Horizontal");
        rb.AddForce(direction.normalized * movementSpeed, ForceMode.Force);
    }

    void ShootBullets()
    {
        Debug.Log("Shooting bullet");
        var instance = Instantiate(bulletPrefab, instancePosition.position, bulletPrefab.transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce(gunOrientation.forward * bulletSpeed);
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse clicked");
        ShootBullets();
    }

    IEnumerator ShootInterval()
    {

        while (true)
        {
            // Your code to be executed every 3 seconds
            Debug.Log("Executing every 1 seconds!");

            if (shouldShoot)
            {
                ShootBullets();
            }

            // Wait for 3 seconds before the next iteration
            yield return new WaitForSeconds(0.1f);
        }
       

    }
}
