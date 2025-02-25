using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed;
    private Transform targetPosition1;//船1
    private Transform targetPosition2;//船2
    private Transform targetPosition3;//車1
    private Transform targetPosition4;//車2
    

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f, 8.0f);
        targetPosition1 = GameObject.Find("Line").GetComponent<Transform>();//船1
        targetPosition2 = GameObject.Find("Line2").GetComponent<Transform>();//船2
        targetPosition3 =GameObject.Find("Line3"). GetComponent<Transform>();//車1
        targetPosition4 = GameObject.Find("Line4").GetComponent<Transform>();//車2

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();

        if ((other.gameObject.tag == "LeftLine")&&(this.gameObject.tag=="boat1"))
        {
            this.gameObject.transform.position= targetPosition1.position;
        }

        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "boat2"))
        {
            this.gameObject.transform.position = targetPosition2.position;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "car1"))
        {
            this.gameObject.transform.position = targetPosition3.position;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "car2"))
        {
            this.gameObject.transform.position = targetPosition4.position;
        }
    }
     void SetRandomSpeed()
     {
        speed = Random.Range(5.0f, 8.0f);
     }
}
