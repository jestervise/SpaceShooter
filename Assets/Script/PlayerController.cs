using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private AudioSource shootSound;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time>nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate<GameObject>(shot,shotSpawn.position, shotSpawn.rotation);
            shootSound = gameObject.GetComponent<AudioSource>();
            shootSound.Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Rigidbody rb=GetComponent<Rigidbody>();
        Vector3 movement=new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity=speed*movement;
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x*-tilt);
        
    }
}
