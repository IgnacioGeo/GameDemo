using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStuckPrevention : MonoBehaviour
{
    public Rigidbody2D boxrb;
    public float force = 5;
    // Start is called before the first frame update
    void Start()
    {
        boxrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    public void OnCollisionEnter(Collision collision)
    {
        //isColliding = Physics.CheckSphere(transform.position, radiusofcollsion);

        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("touched wall");
            /*foreach (ContactPoint contact in collision.contacts)
            {
                Vector2 directionofwalls = contact.point - transform.position;
                directionofwalls = -directionofwalls.normalized;

                boxrb.AddForce(directionofwalls * 15);
                

            }*/
            Vector3 dir = collision.contacts[0].point - transform.position;
            
            dir = -dir.normalized;
            boxrb.AddForce(dir * 15);
        }



        
    }

}
