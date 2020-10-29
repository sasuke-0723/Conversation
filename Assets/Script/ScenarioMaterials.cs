using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Create/Scenario", fileName = "ScenarioMaterials")]
public class ScenarioMaterials : ScriptableObject
{
	[SerializeField] private List<> scenario
}

[Serializable]
public class ScenarioMaterial
{
	/// <summary> キャラクターの名前 </summary>
	[SerializeField] private string name;
	/// <summary> ログに出すテキスト </summary>
	[SerializeField] private string text;
	/// <summary> 会話しているキャラクターの画像 </summary>
	[SerializeField] private Image character;
}

public enum Actor
{
	
}
