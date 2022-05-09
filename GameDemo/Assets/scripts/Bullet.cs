using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dieTime, damage;
    public Rigidbody2D rb;
    //public GameObject diePEFFECT;
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       die(); 
    }

    void Update()
    {
        
    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        die();
    }
    void die()
    {
        Destroy(gameObject);
    }
    
}
