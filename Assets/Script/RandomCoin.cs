using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    public GameObject coin;
    private int numberObjects = 8;//生成する個数エリア
    public GameObject[] areas;//areaの配列
    public GameObject[] specificAreas;//橋のエリア
    bool specificAreaGenerated = false; // specificAreasへの生成フラグ

    // Start is called before the first frame update
    void Start()
    {
        areas = GameObject.FindGameObjectsWithTag("Area");
        PlaceObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceObjects()
    {
        int objectsPlaced = 0;

        // 特定のエリアにコインを1つ生成
        if (specificAreas.Length > 0 && !specificAreaGenerated) // specificAreasが存在し、まだ生成されていない場合
        {
            int randomIndex = Random.Range(0, specificAreas.Length);
            GameObject selectedArea = specificAreas[randomIndex];
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);
            Instantiate(coin, randomPosition, Quaternion.identity);
            objectsPlaced++;
            specificAreaGenerated = true; // specificAreasへの生成フラグを立てる


        }


        // その他のエリアにコインを生成 (numberObjects - 1) 個
        while (objectsPlaced < numberObjects)
        {
            int randomAreaIndex = Random.Range(0, areas.Length);
            GameObject selectedArea = areas[randomAreaIndex];
            Vector3 randomPosition = GetRandomPositionInArea(selectedArea);
            Instantiate(coin, randomPosition, Quaternion.identity);

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

