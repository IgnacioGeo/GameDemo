using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endtrigger : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("DestrucCol"))
        {
            Destroy(collision.gameObject);
        }

    }
}
