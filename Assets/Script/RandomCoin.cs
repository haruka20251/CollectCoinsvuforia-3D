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
    public bool specificAreaGenerated = false; // specificAreasへの生成フラグ
    public LayerMask avoidanceLayerMask; // 衝突判定用のレイヤーマスク

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
        // すべてのコインを削除
        GameObject[] existingCoins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject existingCoin in existingCoins)
        {
            Destroy(existingCoin);
            Debug.Log("Destroyed coin: " + existingCoin.name);
        }
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
            Debug.Log("Generated coin in specific area.");

        }


        // その他のエリアにコインを生成 (numberObjects - 1) 個
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
        // エリアのColliderの範囲内でランダムな位置を生成
        Collider areaCollider = area.GetComponent<Collider>();
        Vector3 minBounds = areaCollider.bounds.min;
        Vector3 maxBounds = areaCollider.bounds.max;

        int maxAttempts = 100; // 最大試行回数
        int attempts = 0;

        while (attempts < maxAttempts)
        {
            float randomX = Random.Range(minBounds.x, maxBounds.x);
            float randomY = 4;
            float randomZ = Random.Range(minBounds.z, maxBounds.z);

            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);
            if (!Physics.CheckSphere(randomPosition, 2f, avoidanceLayerMask))//衝突判定
            {
                return randomPosition; // 衝突しない位置を返す
            }
            attempts++;
        }

        Debug.LogWarning("オブジェクトを避けるための適切な位置が見つかりませんでした。");
        return new Vector3(Random.Range(minBounds.x, maxBounds.x), 4, Random.Range(minBounds.z, maxBounds.z)); // 最大試行回数を超えた場合は、ランダムな位置を返す
    }
}

