using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject bombEffect;
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
}
