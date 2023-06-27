using UnityEngine;
using UnityEngine.UI;
using TMPro;

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


    public void UpdateCoolDown(float totalTime, float remainingTime) {
        coolDownText.gameObject.SetActive(true);
        coolDownFill.gameObject.SetActive(true);

        coolDownFill.fillAmount = remainingTime / totalTime;
        coolDownText.text = Mathf.Round(remainingTime).ToString();

        if (remainingTime <= 0) {
            coolDownText.gameObject.SetActive(false);
            coolDownFill.gameObject.SetActive(false);
        }
    }


    private void UpdateActionButton(SpellInfo spellInfo) {
        GetComponent<Image>().sprite = spellInfo.spellIcon;
        GetComponentInChildren<TMP_Text>().text = spellInfo.spellName;
    }
}

