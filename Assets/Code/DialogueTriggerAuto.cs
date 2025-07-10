using UnityEngine;

public class DialogueTriggerAuto : MonoBehaviour
{
    public DialogueData dialogueData;

    void Start()
    {
        if (dialogueData != null)
        {
            DialogueManager.instance.StartDialogue(dialogueData);
        }
        else
        {
            Debug.LogWarning("AutoDialogueTrigger: No dialogueData assigned.");
        }
    }
}
