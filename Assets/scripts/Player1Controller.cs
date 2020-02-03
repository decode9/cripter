using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

      // Start is called before the first frame update
    void Start()
   {
   }

    // Update is called once per frame
    void Update()
    {

        var move = gameObject.GetComponent<Animator>(); 
    
            if(Input.GetKey("right")) {
                gameObject.transform.Translate(1f * Time.deltaTime, 0, 0);
                move.SetBool("moving", true);
            }

            if(Input.GetKey("left")) {
                gameObject.transform.Translate(-1f * Time.deltaTime, 0, 0);
                move.SetBool("moving", true);
            }

            if(Input.GetKey("up")) {
                gameObject.transform.Translate(0, 1f * Time.deltaTime, 0);
                move.SetBool("moving", true);
            }

            if(Input.GetKey("down")) {
                gameObject.transform.Translate(0, -1f * Time.deltaTime, 0);
                move.SetBool("moving", true);
            }

        
            //moving

            
        
    }
}
