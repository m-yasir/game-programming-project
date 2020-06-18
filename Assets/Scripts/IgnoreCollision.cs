using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();

        foreach (var collider in colliders)
        {
            foreach (var colliderj in colliders)
            {
                Physics2D.IgnoreCollision(collider, colliderj);
            }
        }
    }
}
