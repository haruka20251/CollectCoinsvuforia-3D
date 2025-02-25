using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    private float speed;
    private float randomRangeZ1 = 23;//�_1��Z�������͈�
    private float randomRangeZ2=30;//�_2��Z�������͈�
    //private float xPos;//X���̌Œ�l
    private float randomRangeY=2 ;//Y�������͈�
    private Transform targetPosC1;//�_1
    private Transform targetPosC2;//�_2

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(5.0f, 8.0f);
        targetPosC1=GameObject.Find("cloud_1").GetComponent<Transform>();
        targetPosC2 = GameObject.Find("cloud_2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();
        

        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "cloud1"))
        {
            float xPos = targetPosC1.transform.position.x + 81.14f;
            float randomZ = targetPosC1.transform.position.z + Random.Range(-randomRangeZ1, randomRangeZ1);
            float randomY= targetPosC1.transform.position.y + Random.Range(-randomRangeY, randomRangeY);
            this.gameObject.transform.position = new Vector3(xPos, randomY, randomZ);
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "cloud2"))
        {
            float xPos = targetPosC2.transform.position.x + 81.14f;
            float randomZ = targetPosC2.transform.position.z + Random.Range(-randomRangeZ2, randomRangeZ2);
            float randomY = targetPosC2.transform.position.y + Random.Range(-randomRangeY, randomRangeY);
            this.gameObject.transform.position = new Vector3(xPos, randomY, randomZ);
        }

    }
    void SetRandomSpeed()
    {
        speed = Random.Range(5.0f, 8.0f);
    }
}
