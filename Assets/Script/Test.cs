using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Test : MonoBehaviour
{
    [SerializeField] private Image image;
    private Sprite[] sprite;

    private void Start()
    {
        sprite = Resources.LoadAll<Sprite>("Character");
        image.sprite = sprite[0];
    }

    //private TextAsset csvFile;  // CSVファイル
    //private List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト
    //private int height = 0; // CSVの行数
    //private int i, j = 0;//debugループカウンタ
    //const int size = 9;

    //void Start()
    //{
    //    csvFile = Resources.Load<TextAsset>("CSV/Scenarios"); /* Resouces/CSV下のCSV読み込み */
    //    StringReader reader = new StringReader(csvFile.text);

    //    while (reader.Peek() > -1)
    //    {
    //        string line = reader.ReadLine();
    //        csvDatas.Add(line.Split(',')); // リストに入れる
    //        Debug.Log("reading:" + height);
    //        height++; // 行数加算
    //    }
    //    for (i = 0; i < height; i++)
    //    {
    //        for (j = 0; j < size; j++)
    //        {
    //            Debug.Log("csvDatas[" + i + "][" + j + "]:" + csvDatas[i][j]);
    //        }
    //    }
    //}
}
