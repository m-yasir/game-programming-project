using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public _Muscle[] muscles;

    private void FixedUpdate()
    {
        foreach (var muscle in muscles)
        {
            muscle.ActivateMuscle();
        }
    }
}


[System.Serializable]
public class MUSCLE
{
    public Rigidbody2D bone;
    public float restRotation;
    public float force;

    public void ActivateMuscle()
    {
        bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
    }
}