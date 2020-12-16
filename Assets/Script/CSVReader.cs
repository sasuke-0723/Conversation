using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    /// <summary> CSVから読み込んだTextを格納 </summary>
    private List<string> scenariosData = new List<string>();
    /// <summary> CSVから読み込んだTextの値を格納 </summary>
    private List<int> charNum = new List<int>();

    void Start()
    {
        LoadScenario();
    }

    /// <summary>
    /// 会話文が入ってるCSVファイルの読み込み
    /// </summary>
    private void LoadScenario()
    {
        TextAsset csv = Resources.Load<TextAsset>("CSV/Scenarios");
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {
            string scenarios = reader.ReadLine();
            string[] values = scenarios.Split(',');

            for (int j = 0; j < values.Length - 1; j++)
            {
                scenariosData.Add(values[0]);
                charNum.Add(int.Parse(values[1]));
                //Debug.Log(scenariosData[i] + "," + charNum[i]);
                //Debug.Log(values[i]);
            }
            i++;
        }
    }
}
