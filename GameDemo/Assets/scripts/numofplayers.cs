using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numofplayers : MonoBehaviour
{
    public int players;
    // Start is called before the first frame update
    void Start()
    {
        players = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (players >= 2)
        {
           
        }
    }
    public void addplayers()
    {
        players++;
    }
}
