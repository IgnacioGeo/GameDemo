using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    public int jumpforce =20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("opbetc has touched");
        collision.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

}
