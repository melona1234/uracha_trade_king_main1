using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> PortraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
        talkData=new Dictionary<int, string[]>();
        PortraitData=new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
         //talk data
        talkData.Add(1000, new string[]{"우리 마을을 도와주세요:0"});
        talkData.Add(2000, new string[]{"우리 마을을 도와주세요:0"});
        talkData.Add(3000, new string[]{"마을 사람들의 대화를 듣고 오시게:1"});

        //quest talk
        talkData.Add(10+1000, new string[]{"안녕하세요?:0","우리 나라는 추워서 바나나가 생산되지 않아요:2", "하지만, 백성들은 한번 맛 본 바나나의 맛을 잊지 못하는 것 같아요.:1", "심지어 어떤 사람들은 바나나를 찾기 위해 강도짓을 하고 있다니까요!!:1"});
        talkData.Add(10+2000, new string[]{"안녕하세유?:0", "이번 농사는 아주 흉작이어유...:1", "쌀 농사가 다 망해버렸어유:2", " 쌀값이 폭등을 하고 있는데 어떻게 하면 좋을까유?:1", "다른데서 얻어 올 방법이 없을까유?:2"});
        talkData.Add(20+3000, new string[]{"거기 길 가는 자네, 왜이리 고민이 많아보이는가?:0", "무역을 해보는 것이 어떻겠소?:2", "무역이란 나라와 나라간 물건이나 서비스를 주고 받는 것이라네:0"});

        //portrait data
        PortraitData.Add(1000+0,portraitArr[9]);
        PortraitData.Add(1000+1,portraitArr[10]);
        PortraitData.Add(1000+2,portraitArr[11]);
        PortraitData.Add(2000+0,portraitArr[3]);
        PortraitData.Add(2000+1,portraitArr[4]);
        PortraitData.Add(2000+2,portraitArr[5]);
        PortraitData.Add(3000+0,portraitArr[0]);
        PortraitData.Add(3000+1,portraitArr[1]);
        PortraitData.Add(3000+2,portraitArr[2]);

    }
    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if(!talkData.ContainsKey(id-id%10))
                return GetTalk(id-id%100, talkIndex); //처음 대사 가져옴
            else
                return GetTalk(id-id%10, talkIndex); //기본 대사 가져옴
        }
        if (talkIndex==talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    
    //초상화
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return PortraitData[id+portraitIndex];
    }
}
