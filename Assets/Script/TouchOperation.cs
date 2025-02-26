using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOperation : MonoBehaviour
{
    public GameObject generateScript; // RandomCoinスクリプトがアタッチされたGameObject
    private int initialCoinCount; // 最初に生成されたコインの数

    void Start()
    {
        // コインを生成
        GenerateCoins();

        // 最初に生成されたコインの数を保存
        initialCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast Hit: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Coin")
                {

                    Destroy(hit.collider.gameObject);

                    // コインがすべて消えたら再生成
                    if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                    {
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
            // コインを生成
            script1.PlaceObjects();
        }
        else
        {
            Debug.LogError("GenerateScriptが見つかりません。");
        }
    }
}
