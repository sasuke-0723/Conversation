using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Conversation : MonoBehaviour
{
    /// <summary> CSVから読み込んだTextを格納 </summary>
    private List<string> scenariosData = new List<string>();
    /// <summary> CSVから読み込んだTextの値を格納 </summary>
    private List<int> charNum = new List<int>();
    /// <summary> 会話中に表示するキャラクター </summary>
    private Image[] characters;
    /// <summary> キャラクターを切り替えるSprite </summary>
    private Sprite[] sprites;
    /// <summary> 表示する名前 </summary>
    private string[] charaName = { "胡蝶しのぶ", "冨岡義勇", "竈門炭治郎" };
    /// <summary> MessageWindowのText </summary>
    [SerializeField] Text converText;
    /// <summary> 文字ごとに表示する速度 </summary>
    [SerializeField] private float converSpeed = 0.1f;
    /// <summary> 表示中の会話文 </summary>
    private int converListIndex = 0;
    /// <summary> 表示中の文字 </summary>
    private int converCount = 0;
    /// <summary> 文字スキップのフラグ </summary>
    private bool isSkip = false;
    /// <summary> charaNameを表示するText </summary>
    private Text charaNameText;
    /// <summary> charaNameTextの外枠の色を描画 </summary>
    private Outline textOutLine;

    private void Start()
    {
        characters = GameObject.Find("CharacterSprite").GetComponentsInChildren<Image>();
        sprites = Resources.LoadAll<Sprite>("Character");
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = sprites[i];
        }

        charaNameText = GameObject.Find("CharaName").GetComponent<Text>();
        textOutLine = GameObject.Find("CharaName").GetComponent<Outline>();
        LoadScenario();
        StartCoroutine(ConversationSending());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSkip)
        {
            converText.text = scenariosData[converListIndex].Replace("\\n", "\n");
            converCount = scenariosData[converListIndex].Replace("\\n", "\n").Length;
        }
    }

    private IEnumerator ConversationSending()
    {
        // 全ての会話を表示するまでループ
        while (converListIndex < scenariosData.Count)
        {
            converText.text = string.Empty; // Textのリセット
            converCount = 0;
            isSkip = true;
            CharacterChange();
            CharaNameTextColor();

            // 文字を全て表示していない場合ループ
            while (converCount < scenariosData[converListIndex].Replace("\\n", "\n").Length)
            {
                // Textに一文字ずつ表示
                converText.text += scenariosData[converListIndex].Replace("\\n", "\n")[converCount];
                yield return new WaitForSeconds(converSpeed);
                converCount++;
            }

            isSkip = false;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0)); // マウスが左クリックされるまで待機
            converListIndex++;
        }
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

    private void CharacterChange()
    {
        switch (charNum[converListIndex])
        {
            case 0:
                Debug.Log("胡蝶しのぶ");
                //characters[0].sprite = sprites[0];
                characters[0].enabled = true;
                characters[1].enabled = false;
                characters[2].enabled = false;
                break;
            case 1:
                Debug.Log("富岡義勇");
                //characters[1].sprite = sprites[1];
                characters[1].enabled = true;
                characters[0].enabled = false;
                characters[2].enabled = false;
                break;
            case 2:
                Debug.Log("竈門炭治郎");
                //characters[2].sprite = sprites[2];
                characters[2].enabled = true;
                characters[0].enabled = false;
                characters[1].enabled = false;
                break;
            default:
                break;
        }
    }

    private void CharaNameTextColor()
    {
        switch (charNum[converListIndex])
        {
            case 0:
                charaNameText.text = charaName[0].ToString();
                charaNameText.color = Color.white;
                textOutLine.effectColor = new Color(255, 0, 255);
                break;
            case 1:
                charaNameText.text = charaName[1].ToString();
                charaNameText.color = Color.blue;
                textOutLine.effectColor = Color.black;
                break;
            case 2:
                charaNameText.text = charaName[2].ToString();
                charaNameText.color = Color.red;
                textOutLine.effectColor = Color.black;
                break;
            default:
                break;
        }
    }
}
