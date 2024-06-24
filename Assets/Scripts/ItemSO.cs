using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects/Item")]

public class ItemSO : ScriptableObject
{
    public float damage;
    public string name;
    public int levelNeeded;
    public Sprite icon;
}
