using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoinbridge : MonoBehaviour
{
    public GameObject coin;
    private int numberObjects = 1;//生成する個数
    private GameObject[] areas;//areaの配列

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
        // 配置するオブジェクトの数をカウント
        int objectsPlaced = 0;

        while (objectsPlaced < numberObjects)
        {
            // ランダムなエリアを選択
            int randomAreaIndex = Random.Range(0, areas.Length);
            GameObject selectedArea = areas[randomAreaIndex];

            // エリア内にランダムな位置を生成
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);

            // オブジェクトを生成
            GameObject newObject = Instantiate(coin, randomPosition, Quaternion.identity);

            // オブジェクトが他のオブジェクトと重ならないように調整


            objectsPlaced++;
        }
    }

    Vector3 GetRandomPositionInArea(GameObject area)
    {
        // エリアのColliderの範囲内でランダムな位置を生成
        Collider areaCollider = area.GetComponent<Collider>();
        Vector3 minBounds = areaCollider.bounds.min;
        Vector3 maxBounds = areaCollider.bounds.max;

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = 4;
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
