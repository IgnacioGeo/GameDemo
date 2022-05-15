using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementOfi : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed;
    public float jumpForce;
    private bool isJumping;
    public GameObject PauseMenu;
    public GameObject Win;
    public float endGame=0;

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
            Debug.Log("Space = jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P = pause");
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

        if (endGame==2)
        {
            Debug.Log("End Game");
            Win.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
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
        newVelocity.x = Input.GetAxisRaw("Horizontal") * movementSpeed;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger Enter!");
        endGame = endGame + 1;
        Debug.Log("endGame= "+endGame);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit!");
        endGame = endGame - 1;
        Debug.Log("endGame= " + endGame);
    }
}
