using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoReveal : Projectile
{
    
    // Start is called before the first frame update


    void Start()
    {
        gameObject.tag = "Echo";
        //States the Echo as Echo in tags
    }

    // Update is called once per frame


    /**
     * When the echo hits something with the Enemy Tag
     * It will activate the Debug Log 
     * 
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("triggered ECHO");
        }
    }
}
