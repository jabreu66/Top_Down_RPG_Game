using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [Header("Stats")]
    public string itemName;
   [TextArea] public string itemDescription;
    public Sprite icon;

    public bool isSeeds;

}
