using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOperation : MonoBehaviour
{
    public GameObject generateScript; // RandomCoin�X�N���v�g���A�^�b�`���ꂽGameObject
    private int initialCoinCount; // �ŏ��ɐ������ꂽ�R�C���̐�

    void Start()
    {
        // �R�C���𐶐�
        GenerateCoins();

        // �ŏ��ɐ������ꂽ�R�C���̐���ۑ�
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

                    // �R�C�������ׂď�������Đ���
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
        // RandomCoin�X�N���v�g���擾
        RandomCoin script1 = generateScript.GetComponent<RandomCoin>();

        // RandomCoin�X�N���v�g�����݂���ꍇ
        if (script1 != null)
        {
            // �R�C���𐶐�
            script1.PlaceObjects();
        }
        else
        {
            Debug.LogError("GenerateScript��������܂���B");
        }
    }
}
