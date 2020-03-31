using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using OneEyed.Events;
public class Bird : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float jump, angularDrag;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateBySpeed();
    }

    public void Freeze(bool value)
    {
        if (value)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
    }

    public void Jump()
    {
        rigid.velocity = Vector2.up * jump;
    }

    private void RotateBySpeed()
    {
        var angularVelocity = Vector3.Cross(rigid.velocity, Vector3.left) * angularDrag;
        transform.rotation = Quaternion.Euler(Vector3.ClampMagnitude(angularVelocity, 90));
    }
}
