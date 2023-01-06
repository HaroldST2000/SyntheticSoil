using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArataAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter( Collider Collision){
    if( Collision.gameObject.tag == "particle"){
        Destroy(Collision.gameObject);
    }
   }
}
