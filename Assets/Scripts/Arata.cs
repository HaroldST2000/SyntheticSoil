using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Arata : MonoBehaviour
{
    public GameObject Destructeur;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void arata(){
        GameObject Destroyer = Instantiate(Destructeur, this.transform.position, this.transform.rotation) as GameObject;
        Destroy(Destroyer,2.0f);
    }
   
}
