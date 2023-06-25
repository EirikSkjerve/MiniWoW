using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButton : MonoBehaviour
{
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
}
