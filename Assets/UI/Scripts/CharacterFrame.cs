using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterFrame : MonoBehaviour {
    [SerializeField] private Image healthBar;
    [SerializeField] private Image resourceBar;
    [SerializeField] private Image characterHead;
    [SerializeField] private TMP_Text characterName;


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
    

    public void SetCharacterHead(Sprite newHead) {
        characterHead.sprite = newHead; 
    }


    public void SetCharacterName(string newName) {
        characterName.text = newName;
    }
}
