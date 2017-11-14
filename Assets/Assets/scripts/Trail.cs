using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

    public List<Transform> BodyParts = new List<Transform>();

    public float mindistance = 0.25f;
    public float clockwise = 5.0f; //Turning Speed
    public float counterClockwise = -5.0f; //Turning speed

    public int beginsize;

    public float speed = 1;
    public float rotationspeed = 50;
    

    public GameObject bodyprefab;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodyPart;
    private float time = 0f;
    




	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < beginsize - 1; i++)
        {

            AddBodyPart();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        
        Move();
         
        
           
              AddBodyPart();
        
    
	}

    public void Move()
    {
        //    /*gameObject.transform.position += transform.forward * speed * Time.deltaTime;*/ //Continuously moves player object in direction they are facing
        float curspeed = speed;

        //    //if (Input.GetKey(KeyCode.D)) //Upon pressing D will turn player object
        //    //{
        //    //    transform.Rotate(0, Time.deltaTime * clockwise, 0);
        //    //}
        //    //else if (Input.GetKey(KeyCode.A))// Upon pressing A will turn player object
        //    //{
        //    //    transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        //    //}

        //    //if (Input.GetKey(KeyCode.W))


        //    BodyParts[0].Translate(BodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);

        //    if (Input.GetAxis("Horizontal") != 0)
        //        BodyParts[0].Rotate(Vector3.up * rotationspeed * Time.deltaTime * Input.GetAxis("Horizontal"));



        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            dis = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newpos = prevBodyPart.position;

            newpos.y = BodyParts[0].position.y;

            float T = Time.deltaTime * dis / mindistance * curspeed;

            if (T > 2f)
                T = 2f;
            curBodyPart.position = Vector3.Lerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Lerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        }


    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);
    }
}
