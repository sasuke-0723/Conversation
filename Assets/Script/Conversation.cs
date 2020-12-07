using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Conversation : MonoBehaviour
{
    private GameObject g;
    /// <summary> 会話中に表示するキャラクター </summary>
    [SerializeField] private Image character;
    /// <summary> キャラクターを切り替えるSprite </summary>
    private Sprite[] sprite;
    /// <summary> MessageWindowのText </summary>
    [SerializeField] Text converText;
    /// <summary> CSVから読み込んだTextを格納 </summary>
    private List<string> scenariosData = new List<string>();
    /// <summary> CSVから読み込んだTextの値を格納 </summary>
    private List<int> charNum = new List<int>();
    /// <summary> 文字ごとに表示する速度 </summary>
    [SerializeField] private float converSpeed = 0.1f;
    /// <summary> 表示中の会話文 </summary>
    private int converListIndex = 0;
    /// <summary> 表示中の文字 </summary>
    private int converCount = 0;
    /// <summary> 文字スキップのフラグ </summary>
    private bool isSkip = false;

    private void Start()
    {
        sprite = Resources.LoadAll<Sprite>("Character");
        character = this.GetComponent<Image>();
        LoadCSV();
        StartCoroutine(ConversationSending());
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && isSkip)
        //{
        //    converCount = scenariosData[converListIndex].Replace("\\n", "\n").Length;
        //}
        //CharacterChange();

    }

    private IEnumerator ConversationSending()
    {
        while (converListIndex < scenariosData.Count)
        {
            converText.text = string.Empty;
            converCount = 0;

            while (converCount < scenariosData[converListIndex].Replace("\\n", "\n").Length)
            {
                isSkip = true;
                converText.text += scenariosData[converListIndex].Replace("\\n", "\n")[converCount];
                yield return new WaitForSeconds(converSpeed);
                converCount++;
            }

            isSkip = false;
            converListIndex++;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            //StartCoroutine(ConversationSending());
        }
    }

    private void LoadCSV()
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

    //private void CharacterChange()
    //{
    //    switch (charNum[converListIndex])
    //    {
    //        case 0:
    //            Debug.Log("胡蝶しのぶ");
    //            character.sprite = sprite[0];
    //            break;
    //        case 1:
    //            Debug.Log("富岡義勇");
    //            character.sprite = sprite[1];
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
