using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{

    /*void OnTriggerEnter(Collider _col)  // Ʈ���ſ� �浹�� �Ǿ��� ���� �� �Լ��� �����Ѵ�.
    {
        if (_col.gameObject.name == "Player")
        {
            
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("sea");
    }
}
