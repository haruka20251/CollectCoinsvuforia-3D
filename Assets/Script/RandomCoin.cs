using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject coin;
    private int numberObjects = 8;//����������G���A
    public GameObject[] areas;//area�̔z��
    public GameObject[] specificAreas;//���̃G���A
    public bool specificAreaGenerated = false; // specificAreas�ւ̐����t���O

    // Start is called before the first frame update
    void Start()
    {
        areas = GameObject.FindGameObjectsWithTag("Area");
        specificAreaGenerated = false;
        PlaceObjects();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceObjects()
    {
        Debug.Log("PlaceObjects() called.");
        // ���ׂẴR�C�����폜
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject existingCoin in existingCoins)
        {
            Destroy(existingCoin);
            Debug.Log("Destroyed coin: " + existingCoin.name);
        }
        int objectsPlaced = 0;

        // ����̃G���A�ɃR�C����1����
        if (specificAreas.Length > 0 && !specificAreaGenerated) // specificAreas�����݂��A�܂���������Ă��Ȃ��ꍇ
        {
            int randomIndex = Random.Range(0, specificAreas.Length);
            GameObject selectedArea = specificAreas[randomIndex];
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);
            Instantiate(coin, randomPosition, Quaternion.identity);
            objectsPlaced++;
            specificAreaGenerated = true; // specificAreas�ւ̐����t���O�𗧂Ă�
            Debug.Log("Generated coin in specific area.");

        }


        // ���̑��̃G���A�ɃR�C���𐶐� (numberObjects - 1) ��
        while (objectsPlaced < numberObjects)
        {
            int randomAreaIndex = Random.Range(0, areas.Length);
            GameObject selectedArea = areas[randomAreaIndex];
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);
            Instantiate(coin, randomPosition, Quaternion.identity);

            objectsPlaced++;

            Debug.Log("Generated coin in other area.");
        }
        Debug.Log("PlaceObjects() finished.");
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

