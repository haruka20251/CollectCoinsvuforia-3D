using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoinbridge : MonoBehaviour
{
    public GameObject coin;
    private int numberObjects = 1;//���������
    private GameObject[] areas;//area�̔z��

    // Start is called before the first frame update
    void Start()
    {
        areas = GameObject.FindGameObjectsWithTag("Area2");
        PlaceObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlaceObjects()
    {
        // �z�u����I�u�W�F�N�g�̐����J�E���g
        int objectsPlaced = 0;

        while (objectsPlaced < numberObjects)
        {
            // �����_���ȃG���A��I��
            int randomAreaIndex = Random.Range(0, areas.Length);
            GameObject selectedArea = areas[randomAreaIndex];

            // �G���A���Ƀ����_���Ȉʒu�𐶐�
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);

            // �I�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(coin, randomPosition, Quaternion.identity);

            // �I�u�W�F�N�g�����̃I�u�W�F�N�g�Əd�Ȃ�Ȃ��悤�ɒ���


            objectsPlaced++;
        }
    }

    Vector3 GetRandomPositionInArea(GameObject area)
    {
        // �G���A��Collider�͈͓̔��Ń����_���Ȉʒu�𐶐�
        Collider areaCollider = area.GetComponent<Collider>();
        Vector3 minBounds = areaCollider.bounds.min;
        Vector3 maxBounds = areaCollider.bounds.max;

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = 4;
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
