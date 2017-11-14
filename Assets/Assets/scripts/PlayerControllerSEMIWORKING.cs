using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerSEMIWORKING : MonoBehaviour
{


    
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F; //Currently unused
    public float gravity = 20.0F; //Currently unused
    public float clockwise = 5.0f; //Turning Speed
    public float counterClockwise = -5.0f; //Turning speed

    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }






    private void FixedUpdate()
    {

        

        gameObject.transform.position += transform.forward * speed * Time.deltaTime; //Continuously moves player object in direction they are facing

        

        if (Input.GetKey(KeyCode.D)) //Upon pressing D will turn player object
        {
            transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
        else if (Input.GetKey(KeyCode.A))// Upon pressing A will turn player object
        {
            transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        }

        
    }

        


    





    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            
        }
    }

    
}
