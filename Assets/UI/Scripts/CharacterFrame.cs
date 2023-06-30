using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterFrame : MonoBehaviour {
    [SerializeField] private Image healthBar;
    [SerializeField] private Image resourceBar;
    [SerializeField] private Image characterHead;
    [SerializeField] private TMP_Text characterName;

    private CharacterInfo _characterInfo;   
    public CharacterInfo CharacterInfo {
        get { return _characterInfo; }
        set {
            _characterInfo = value;
            SetCharacterInfo(value);
        }
    }


    public void UpdateHealthBar(float fillRatio) {
        if (fillRatio > 1 || fillRatio < 0) {
            Debug.LogError("Update health bar failed: Fill ratio must be between 0 and 1, was " + fillRatio);
            return;
        }

        healthBar.fillAmount = fillRatio;
    }


    public void UpdateResourceBar(float fillRatio) {
        if (fillRatio > 1 || fillRatio < 0) {
            Debug.LogError("Update resource bar failed: Fill ratio must be between 0 and 1, was " + fillRatio);
            return;
        }

        resourceBar.fillAmount = fillRatio;
    }
    
    private void SetCharacterInfo(CharacterInfo characterInfo) {
        characterHead.sprite = characterInfo.characterHead;
        characterName.text = characterInfo.characterName;
    }
}
