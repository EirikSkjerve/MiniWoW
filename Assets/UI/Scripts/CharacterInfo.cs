using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo", menuName = "ScriptableObjects/CharacterInfo", order = 1)]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public Sprite characterHead;
}
