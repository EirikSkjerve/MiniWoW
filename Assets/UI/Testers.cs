using UnityEngine;

public class Testers : MonoBehaviour
{
    [SerializeField] private GameObject characterFrame;
    private CharacterFrame _characterFrameScript;

    [SerializeField] private GameObject targetFrame;
    private CharacterFrame _targetFrameScript;

    [SerializeField] private GameObject actionBar;

    [Range(0f, 1f)]
    [SerializeField] private float characterHealthRatio;

    [Range(0f, 1f)]
    [SerializeField] private float characterResourceRatio;

    [Range(0f, 1f)]
    [SerializeField] private float targetHealthRatio;

    [Range(0f, 1f)]
    [SerializeField] private float targetResourceRatio;

    [SerializeField] private GameObject actionButtonTest;
    [SerializeField] private SpellInfo spellInfoTest;

    [SerializeField] private CharacterInfo characterInfoTest;
    [SerializeField] private CharacterInfo targetInfoTest;

    // Start is called before the first frame update
    void Start()
    {
        _characterFrameScript = characterFrame.GetComponent<CharacterFrame>();
        _characterFrameScript.CharacterInfo = characterInfoTest;

        _targetFrameScript = targetFrame.GetComponent<CharacterFrame>();
        _targetFrameScript.CharacterInfo = targetInfoTest;

        actionButtonTest.GetComponent<ActionButton>().SpellInfo = spellInfoTest;
    }

    // Update is called once per frame
    void Update()
    {
        _characterFrameScript.UpdateHealthBar(characterHealthRatio);
        _characterFrameScript.UpdateResourceBar(characterResourceRatio);

        _targetFrameScript.UpdateHealthBar(targetHealthRatio);
        _targetFrameScript.UpdateResourceBar(targetResourceRatio);
    }
}
