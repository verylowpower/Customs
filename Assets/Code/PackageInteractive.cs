using UnityEngine;

public class PackageInteractive : MonoBehaviour
{
    public Animator animator;
    public DialogueData packageDialogue;
    public ChoiceEvent choiceEvent;
    public bool openedPackage = false;

    void OnMouseDown()
    {
        // block mouse click when dialogue is running
        if (DialogueManager.instance.isTalking) return;

        Debug.Log("CLICKED: " + gameObject.name);


        if (animator != null)
            animator.SetBool("isPlaying", true);

        // show package dialogue
        if (packageDialogue != null)
            DialogueManager.instance.StartDialogue(packageDialogue);

        openedPackage = true;
        Debug.Log($"{gameObject.name} opened ");

    }
}
