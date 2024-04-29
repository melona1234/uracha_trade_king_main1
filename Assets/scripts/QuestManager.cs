using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;  //퀘스트 대화 순서
    public GameObject[] questObject;
    Dictionary<int, QuestData> questlist;

    void Awake()
    {
        questlist=new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questlist.Add(10, new QuestData("village talk",new int[]{1000, 2000}));
        questlist.Add(20, new QuestData("grandpa",new int[]{3000}));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }
 
    public string CheckQuest(int id)
    {
        //next talk target
        if(id==questlist[questId].npcId[questActionIndex])
            questActionIndex++;
        
        //talk complete & new quest
        if (questActionIndex==questlist[questId].npcId.Length)
            NextQuest();

        //questname
        return questlist[questId].questName;
    }

    public string CheckQuest()
    {
        return questlist[questId].questName;
    }

    //다음 퀘스트를 위한 함수
    void NextQuest()
    {
        questId+=10;
        questActionIndex=0;
    }

}
