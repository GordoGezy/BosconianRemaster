using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with self-destruction and firing
public class HarvesterNodeController : MonoBehaviour {

    GameObject player;
    Vector3 cannonPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        cannonPosition = transform.Find("Cannon").position;
        Debug.Log(cannonPosition);
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hit;
        var rayDirection = player.GetComponent<Transform>().position - cannonPosition;
        //Debug.Log("checking");
        if (Physics.Raycast(cannonPosition, rayDirection, out hit, 10))
        {
            if (hit.transform == player)
            {
                Debug.Log(gameObject.name + "is shooting");
            }
            else
            {
                Debug.Log(gameObject.name + "is not shooting");
            }
        }
        Debug.DrawLine(cannonPosition, player.transform.position);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player Bullet")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Debug.Log("Colliding with node");
            Destroy(gameObject.transform.parent.gameObject);
        }

    }
}
