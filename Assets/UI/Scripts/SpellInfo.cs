using UnityEngine;

///<summary>
/// SpellInfo is a class that hold information about a spell.
/// It is a ScriptableObject, so it can be created as an asset in the project and be 
/// used by other scripts.
///</summary>
///<remarks>
///Author: Kaspar Moberg
///</remarks>
[CreateAssetMenu(fileName = "SpellInfo", menuName = "ScriptableObjects/SpellInfo", order = 1)]
public class SpellInfo : ScriptableObject
{
    public string spellName;
    public string spellDescription;
    public Sprite spellIcon;
    public float spellCooldown;
}
