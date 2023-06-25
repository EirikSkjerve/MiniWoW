using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testers : MonoBehaviour
{
    [SerializeField] private GameObject characterFrame;
    private CharacterFrame _characterFrameScript;

    [SerializeField] private GameObject actionBar;
    private ActionBar _actionBarScript;

    [Range(0f, 1f)]
    [SerializeField] private float healthRatio;

    [Range(0f, 1f)]
    [SerializeField] private float resourceRatio;

    [SerializeField] private Sprite characterHead;

    [SerializeField] private string characterName;

    [SerializeField] private float totalTime;
    [SerializeField] private float remainingTime;
    [SerializeField] private int actionButton;
    [SerializeField] private bool countDown;

    // Start is called before the first frame update
    void Start()
    {
        _characterFrameScript = characterFrame.GetComponent<CharacterFrame>();
        _actionBarScript = actionBar.GetComponent<ActionBar>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterFrameScript.UpdateHealthBar(healthRatio);
        _characterFrameScript.UpdateResourceBar(resourceRatio);
        _characterFrameScript.SetCharacterHead(characterHead);
        _characterFrameScript.SetCharacterName(characterName);

        _actionBarScript.UpdateCoolDown(actionButton, totalTime, remainingTime);
        if (remainingTime > 0 && countDown) { remainingTime -= Time.deltaTime; }
    }
}
