using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Deals with dying, spawning squadrons, and shooting rockets
public class HarvesterController : MonoBehaviour
{
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player Bullet" 
            && other.transform.position.y > -1.5
            && other.transform.position.y < 1.5
            && other.transform.position.x > -1.5
            && other.transform.position.x < 1.5)
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            Debug.Log("Colliding with harvester");
            Destroy(gameObject);
        }

    }
}