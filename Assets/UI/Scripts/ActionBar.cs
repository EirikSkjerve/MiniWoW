using UnityEngine;

public class ActionBar : MonoBehaviour
{
    public void UpdateCoolDown(int actionButton, float totalTime, float remainingTime) {
        var actionButtonObject = transform.GetChild(actionButton);
        var actionButtonScript = actionButtonObject.GetComponent<ActionButton>();

        actionButtonScript.UpdateCoolDown(remainingTime);
    }
}
