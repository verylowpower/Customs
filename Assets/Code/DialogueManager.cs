using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI speakerText;
    public TextMeshProUGUI dialogueText;

    private Queue<DialogueLine> lines = new();
    public bool isTalking = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void StartDialogue(DialogueData data)
    {
        if (isTalking) return;

        dialoguePanel.SetActive(true);
        lines.Clear();

        foreach (var line in data.lines)
            lines.Enqueue(line);

        isTalking = true;
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = lines.Dequeue();
        speakerText.text = line.speakerName;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(line.sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char c in sentence)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.015f);
        }
    }

    void Update()
    {
        if (isTalking && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextLine();
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isTalking = false;
    }
}
