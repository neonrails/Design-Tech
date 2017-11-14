using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed = 1;
    public GameObject Player;
    public Transform Target;
    public Camera cam;

    private Vector3 offset;


    void LateUpdate()
    {
        Move(); 
    }

    public void Move()
    {
        Vector3 direction = (Target.position - cam.transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        lookrotation.x = transform.rotation.x;
        lookrotation.z = transform.rotation.z;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 100);

        transform.position = Vector3.Slerp(transform.position, Target.position, Time.deltaTime * speed);
    }

    //// Use this for initialization
    //void Start () {
    //       offset = transform.position - Player.transform.position;

    //}

    //// Update is called once per frame
    //void LateUpdate () {
    //       transform.position = Player.transform.position + offset;

    //}
}
