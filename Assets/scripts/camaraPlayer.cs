using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraPlayer : MonoBehaviour
{

    public float smooth;
    public Transform player;

    public Vector3 playerFollow;

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.position + playerFollow,smooth*Time.deltaTime);
    }
}
