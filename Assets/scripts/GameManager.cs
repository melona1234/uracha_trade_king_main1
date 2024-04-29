using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public TextMeshProUGUI talkText;
    public GameObject scanObject;
    public Image portraitImg;
    public GameObject talkPanel;
    public bool isAction;
    public TMP_InputField inputText;
    public int talkIndex;

    void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void selectChar(int num)
    {
        PlayerPrefs.SetInt("playerNumber", num);
        PlayerPrefs.Save();
    }

    public void setPlayerName(string name)
    {
        name = inputText.text;
        PlayerPrefs.SetString("playerName", name);
        PlayerPrefs.Save();
    }

    public void Action(GameObject scanObj)
    {
        //현재 오브젝트 가져오기
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        //set talk data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        //end talk
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest();  //?
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        //continue talk
        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;

    }
}
