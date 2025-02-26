using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOperation : MonoBehaviour
{
    public GameObject generateScript; // RandomCoinスクリプトがアタッチされたGameObject
    private int initialCoinCount; // 最初に生成されたコインの数
    private int coinLayerMask;// Coinレイヤーマスク

    void Start()
    {
        // コインを生成
        GenerateCoins();

        // 最初に生成されたコインの数を保存
        initialCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinLayerMask = LayerMask.GetMask("Coin");
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch detected."); // 追加

            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            // Raycastにレイヤーマスクを適用
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, coinLayerMask))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name); // 追加
                if (hit.collider.gameObject.tag == "Coin")
                {
                    Debug.Log("Coin tag detected."); // 追加
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(RegenerateAfterDelay());
                }
                IEnumerator RegenerateAfterDelay()
                {
                    yield return null; // 1フレーム待機
                    // コインがすべて消えたら再生成
                    if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                    {
                        Debug.Log("No coins left."); // 追加
                        GenerateCoins();
                    }
                }
            }
        }
    }

    void GenerateCoins()
    {
        // RandomCoinスクリプトを取得
        RandomCoin script1 = generateScript.GetComponent<RandomCoin>();

        // RandomCoinスクリプトが存在する場合
        if (script1 != null)
        {
            Debug.Log("Reset specificAreaGenerated");
            script1.specificAreaGenerated = false;
            // コインを生成
            script1.PlaceObjects();
        }
        else
        {
            Debug.LogError("GenerateScriptが見つかりません。");
        }
    }
}
