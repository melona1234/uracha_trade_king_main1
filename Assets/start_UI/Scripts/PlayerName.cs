using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Name").GetComponent<TMP_Text>();
        text.text=PlayerPrefs.GetString("playerName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
