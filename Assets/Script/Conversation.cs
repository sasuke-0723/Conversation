using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
	/// <summary> 会話の内容を格納するリスト </summary>
	[TextArea]
	[SerializeField] private List<string> conversationList = new List<string>();
	/// <summary> 会話の内容を格納リスト(2人目) </summary>
	[TextArea]
	[SerializeField] private List<string> conversationList1 = new List<string>();
	/// <summary> MessageWindowのText </summary>
	[SerializeField] private Text converText = null;
	/// <summary> 文字ごとに表示する速さ </summary>
	[SerializeField] private float converSpeed;
	/// <summary> 現在表示中の会話の配列 </summary>
	private int converListIndex = 0;
	/// <summary> 現在表示している文字 </summary>
	private int converCount = 0;
	/// <summary> スキップする為のフラグ </summary>
	private bool isSkip = false;


	private void Start()
	{
		StartCoroutine(ConversationSending());
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && isSkip)
		{
			converText.text = conversationList[converListIndex];
			converCount = conversationList[converListIndex].Length;
		}
	}

	private IEnumerator ConversationSending()
	{
		converText.text = "";

		// 文字を全て表示していない場合ループさせる
		while (conversationList[converListIndex].Length > converCount)
		{
			isSkip = true;
			converText.text += conversationList[converListIndex][converCount];
			converCount++;
			yield return new WaitForSeconds(converSpeed);
		}

		isSkip = false;
		converCount = 0;
		converListIndex++;

		if (converListIndex < conversationList.Count)
		{
			yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
			StartCoroutine(ConversationSending());
		}
	}

	//private IEnumerator Start()
	//{
	//	var text = new string[]
	//	{
	//		"もしも～し",
	//		"もしも～し",
	//		"大丈夫ですか～？",
	//		"こんばんは",
	//		"今夜は月がきれいですね"
	//	};

	//	for (int i = 0; i < text.Length; i++)
	//	{
	//		Debug.Log(i);
	//		converText.text = text[i];
	//		yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
	//		yield return null;

	//		if (i == text.Length - 1)
	//		{
	//			i = 0;
	//		}
	//	}
	//}
}
