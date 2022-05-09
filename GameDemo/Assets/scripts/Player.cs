using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //public fields
    public float speed = 1.0f;
    //private fields
    Rigidbody2D rb;
    float horizValue;
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
