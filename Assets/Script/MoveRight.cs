using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed;
    private Transform targetPosR1;//�E��1
    private Transform targetPosR2;//�E��1
    private Transform targetPosR3;//�E�D1
    private Transform targetPosR4;//��s�@

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f, 8.0f);
        targetPosR1 = GameObject.Find("LineR1").GetComponent<Transform>();//�E��1
        targetPosR2 = GameObject.Find("LineR2").GetComponent<Transform>();//�E��1
        targetPosR3 = GameObject.Find("LineR3").GetComponent<Transform>();//�E�D1
        targetPosR4 = GameObject.Find("LineR4").GetComponent<Transform>();//��s�@
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();

        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "carR1"))
        {
            this.gameObject.transform.position = targetPosR1.position;
        }

        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "carR2"))
        {
            this.gameObject.transform.position = targetPosR2.position;
        }
        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "boatR1"))
        {
            this.gameObject.transform.position = targetPosR3.position;
        }
        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "plane1"))
        {
            this.gameObject.transform.position = targetPosR4.position;
        }
    }
    void SetRandomSpeed()
    {
        speed = Random.Range(5.0f, 8.0f);
    }
}
