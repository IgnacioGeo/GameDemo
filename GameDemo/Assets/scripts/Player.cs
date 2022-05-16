using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{   //public fields
    public float speed = 1.0f;
    //private fields
    Rigidbody2D rb;
    float horizValue;

    public override void OnNetworkSpawn()
    {
        if (IsOwner && IsClient)
        {
            Update();
            FixedUpdate();
            base.OnNetworkSpawn();
        }
    }
    void Awake()
    {
       rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       horizValue = Input.GetAxisRaw("Horizontal");
       //Debug.Log(horizValue);
    }
    void FixedUpdate()
    {
        Move(horizValue);
    }
    void Move(float dir)
    {
        float xVal = dir * speed * 100 * Time.deltaTime;
        Vector2 target = new Vector2(xVal,rb.velocity.y);
        rb.velocity = target;
    }
}
