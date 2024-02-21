using UnityEngine;

public class YarnSpinnerNode : MonoBehaviour
{
    public string nodeName;

    private Yarn.Unity.DialogueRunner dialogueRunner;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }

    public void ActivateNode()
    {
        if (!string.IsNullOrEmpty(nodeName) && dialogueRunner != null)
        {
            dialogueRunner.StartDialogue(nodeName);
        }
    }
}
