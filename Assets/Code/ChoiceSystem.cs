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

        if (currentChoice != null && currentChoice.linkedObject != null && !currentChoice.linkedObject.openedPackage)
        {
            currentChoice.ChooseSkipPass();
        }
        else
        {
            currentChoice?.ChoosePass();

            if (currentChoice?.linkedObject?.openedPackage == true)
            {
                ObjectViewer.instance?.HideModel();
                currentChoice.linkedObject.isViewingModel = false;
            }
        }
    }


    public void OnDenyPressed()
{
    Debug.Log("Deny");
    chooseDeny = true;

    if (currentChoice != null && currentChoice.linkedObject != null && !currentChoice.linkedObject.openedPackage)
    {
        currentChoice.ChooseSkipDeny();
    }
    else
    {
        currentChoice?.ChooseDeny();
       
        if (currentChoice?.linkedObject?.openedPackage == true)
        {
            ObjectViewer.instance?.HideModel();
            currentChoice.linkedObject.isViewingModel = false;
        }
    }
}


    public void ClearChoices()
    {
        choosePass = false;
        chooseDeny = false;
    }
}
