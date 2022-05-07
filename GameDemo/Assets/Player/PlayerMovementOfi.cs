using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOfi : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    public float jumpForce;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }




    private void FixedUpdate()
    {
        Vector2 newVelocity;
        newVelocity.x = Input.GetAxisRaw("Horizontal");
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }


}
