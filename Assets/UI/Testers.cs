using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testers : MonoBehaviour
{
    [SerializeField] private GameObject characterFrame;
    private CharacterFrame _characterFrameScript;

    [SerializeField] private GameObject actionBar;

    [Range(0f, 1f)]
    [SerializeField] private float healthRatio;

    [Range(0f, 1f)]
    [SerializeField] private float resourceRatio;

    [SerializeField] private Sprite characterHead;

    [SerializeField] private string characterName;

    [SerializeField] private GameObject actionButtonTest;
    [SerializeField] private SpellInfo spellInfoTest;

    // Start is called before the first frame update
    void Start()
    {
        _characterFrameScript = characterFrame.GetComponent<CharacterFrame>();
        actionButtonTest.GetComponent<ActionButton>().SpellInfo = spellInfoTest;
    }

    // Update is called once per frame
    void Update()
    {
        _characterFrameScript.UpdateHealthBar(healthRatio);
        _characterFrameScript.UpdateResourceBar(resourceRatio);
        _characterFrameScript.SetCharacterHead(characterHead);
        _characterFrameScript.SetCharacterName(characterName);        
    }
}
