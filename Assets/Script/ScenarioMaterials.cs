using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioMaterials : MonoBehaviour
{
    private CSVWriter csv;
    /// <summary> 会話文 </summary>
    string[] conversation = new string[]
    {
        "どうして邪魔をするんです？富岡さん、\n" +
        "鬼とは仲良くできないって言ってたくせに\n何なんでしょうか, 0",
        "そんなだから、みんなに嫌われるんですよ, 0",
        "俺は嫌われてない, 1",
        "えっ！, 2",
        "!!!, 0",
        "あ〜、それ、すみません、\n嫌われている自覚がなかったんですね。\n" +
        "余計なことを言ってしまって申し訳ないです。, 0",
        "!!!, 1",
        "えぇ〜〜〜っ!, 2",
        "あっ！, 2",
    };

    private void Start()
    {
        csv = GameObject.Find("CSV").GetComponent<CSVWriter>();
        for (int i = 0; i < conversation.Length; i++)
        {
            csv.WriteCSV(conversation[i]);
        }
    }
}