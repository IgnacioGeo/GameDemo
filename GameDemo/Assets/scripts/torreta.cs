using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta : MonoBehaviour
{
    public float range,walkspeed;
    //public bool canshoot;
    public Transform player;
    public GameObject gun;
    public GameObject bullet;
    //public GameObject bulletIns;
    public Transform shootpoint;
    public Rigidbody2D rb;
    public float firerate, force;
    public float timebtwshoots =0;

    Vector2 Direction;
    bool dectected = false;
    void Start()
    {        
        //canshoot = true;
       // player = GameObject.Find("player");
    } 
    void Update()
    {
        Vector2 Playerpos = player.position;
        Direction = Playerpos - (Vector2)transform.position;
        RaycastHit2D rayinfo = Physics2D.Raycast(transform.position, Direction, range);
        if (rayinfo)
        {
            if (rayinfo.collider.gameObject.tag == "Player")
            {
                if (dectected == false)
                {
                    dectected = true;
                }
            }
            else
            {
                if (rayinfo.collider.gameObject.tag == "Player")
                {
                    if (dectected == true)
                    {
                        dectected = false;
                    }
                }
            }
            if (dectected)
            {
                gun.transform.up = Direction;
                if (Time.time > timebtwshoots)
                {
                    timebtwshoots = Time.time + 1 / firerate;
                    shoot();
                }
            }
        }
    
       
    }
    void shoot()
    {
        GameObject bulletIns = Instantiate(bullet, shootpoint.position, Quaternion.identity);
        bulletIns.GetComponent<Rigidbody>().AddForce(Direction * force);
    }
    


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

