using UnityEngine;
using UnityEngine.UI;
using TMPro;

///<summary>
/// Contains functionality of an Action button. This involes showing the appropritate name 
/// and icon of a spell, aswell as graphically showing the remaining cooldown of the spell at the
/// assigned action button.
///</summary>
public class ActionButton : MonoBehaviour
{
    private SpellInfo _spellInfo;

    public SpellInfo SpellInfo {
        get { return _spellInfo; }
        set {
            _spellInfo = value;
            UpdateActionButton(value);
        }
    }

    [SerializeField] private Image coolDownFill;
    [SerializeField] private TMP_Text coolDownText;

    ///<summary>
    /// Updates the cooldown elements of the action button given a remaining cooldown
    ///</summary>
    ///<param name="remainingTime">The remaining cooldown time of the spell</param>
    public void UpdateCoolDown(float remainingTime) {
        coolDownText.gameObject.SetActive(true);
        coolDownFill.gameObject.SetActive(true);

        coolDownFill.fillAmount = remainingTime / SpellInfo.spellCooldown;
        coolDownText.text = Mathf.Round(remainingTime).ToString();

        if (remainingTime <= 0) {
            coolDownText.gameObject.SetActive(false);
            coolDownFill.gameObject.SetActive(false);
        }
    }

    
    ///<summary>
    /// Sets the information given as a SpellInfo as the graphics for the action button. Updates the icon and name
    ///</summary>
    ///<param name="spellInfo">The SpellInfo object containing the info of the spell</param>
    private void UpdateActionButton(SpellInfo spellInfo) {
        GetComponent<Image>().sprite = spellInfo.spellIcon;
        GetComponentInChildren<TMP_Text>().text = spellInfo.spellName;
    }
}

