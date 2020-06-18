using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float force = 70f;
    public float forceMultiplier = 1000;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && rb)
        {
            Vector2 d = rb.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            d = d.normalized;
            rb.AddForce(-d * force * Time.deltaTime * forceMultiplier);
        }
    }
}
