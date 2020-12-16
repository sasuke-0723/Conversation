using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChange : MonoBehaviour
{
    [SerializeField] private Image character;
    private Sprite[] chara;
    private int num;
    public int Num { set { num = value; } }

    private void Start()
    {
        chara = Resources.LoadAll<Sprite>("Character");

    }

    private void ChangeCharacter()
    {
        
    }
}
