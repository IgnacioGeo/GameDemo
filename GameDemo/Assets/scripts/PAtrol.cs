using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAtrol : MonoBehaviour
{
    public float walkspeed,range,timeBTWShots,shootSpeed;
    private float DistToPlayer;
    [HideInInspector]
    public bool mustpatrol;
    public bool mustflip,canshoot;
    public Rigidbody2D rb;
    public Transform groundcheckPos,player, shootPos;
    public LayerMask groundLayer;
    public Collider2D bodycollider;
    public GameObject bullet;
    void Start()
    {
        mustpatrol = true;
        canshoot = true;
       // player = GameObject.Find("player");
    } 
    void Update()
    {
        if(mustpatrol)
        {
            Patrol();
        }

        DistToPlayer=Vector2.Distance(transform.position,player.position);
        
        if(DistToPlayer<=range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || 
                player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                flip();
            }
            mustpatrol = false;
            rb.velocity = Vector2.zero;
            if(canshoot)            
            StartCoroutine(Shoot());
        }
        else
        {
            mustpatrol = true;
        }
    }
    void FixedUpdate()
    {
        if (mustpatrol)
        {
            mustflip = !Physics2D.OverlapCircle(groundcheckPos.position,0.1f,groundLayer);
        }
    }
    void Patrol()
    {
        if(mustflip || bodycollider.IsTouchingLayers(groundLayer))
        {
            flip();
        }
        rb.velocity = new Vector2(walkspeed*Time.fixedDeltaTime,rb.velocity.y);
    }

    void flip()
    {
        mustpatrol = false;
        transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
        walkspeed *= -1;
        mustpatrol = true;
    }
    IEnumerator Shoot()
    {
        canshoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet,shootPos.position,Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed *walkspeed* Time.fixedDeltaTime,0f);
        canshoot = true;
    }
}

