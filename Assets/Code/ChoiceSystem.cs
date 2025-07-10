using UnityEngine;

public class ChoiceSystem : MonoBehaviour
{
    public static ChoiceSystem instance;
    private ChoiceEvent currentChoice;

    public bool choosePass = false;
    public bool chooseDeny = false;

    void Awake() => instance = this;

    public void SetCurrentChoice(ChoiceEvent choice)
    {
        currentChoice = choice;
        Debug.Log("Set current choice: " + choice?.name);
    }

    public void OnPassPressed()
    {
        Debug.Log("Pass");
        choosePass = true;

        // Nếu chưa mở package → skip pass
        if (currentChoice != null && currentChoice.linkedObject != null && !currentChoice.linkedObject.openedPackage)
        {
            currentChoice.ChooseSkipPass();
        }
        else
        {
            currentChoice?.ChoosePass();
        }
    }

    public void OnDenyPressed()
    {
        Debug.Log("Deny");
        chooseDeny = true;

        // Nếu chưa mở package → skip deny
        if (currentChoice != null && currentChoice.linkedObject != null && !currentChoice.linkedObject.openedPackage)
        {
            currentChoice.ChooseSkipDeny();
        }
        else
        {
            currentChoice?.ChooseDeny();
        }
    }

    public void ClearChoices()
    {
        choosePass = false;
        chooseDeny = false;
    }
}
