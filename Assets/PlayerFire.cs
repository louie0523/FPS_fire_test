using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;
    public float throwPower = 15f;

    private float throwCooldown = 3f;
    private float lastThrowTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= lastThrowTime + throwCooldown)
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        GameObject bomb = Instantiate(bombFactory);
        bomb.transform.position = firePosition.transform.position;

        Rigidbody rb = bomb.GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);

        lastThrowTime = Time.time;
    }
}
