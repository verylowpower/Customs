using UnityEngine;

public class ChoiceEvent : MonoBehaviour
{
    public PackageInteractive linkedObject; // Object kiểm tra trạng thái mở package

    public EndingType passEnding;
    public int passPoint = 1;

    public EndingType denyEnding;
    public int denyPoint = 1;

    public EndingType skipPassEnding;
    public int skipPassPoint = 1;

    public EndingType skipDenyEnding;
    public int skipDenyPoint = 1;

    public GameObject currentObject;
    public GameObject nextObject;

    void Start()
    {
        if (ChoiceSystem.instance != null)
            ChoiceSystem.instance.SetCurrentChoice(this);
    }

    public void ChoosePass()
    {
        GameProgressManager.instance.AddPoint(passEnding, passPoint);
        Transition(nextObject);
        
    }

    public void ChooseDeny()
    {
        GameProgressManager.instance.AddPoint(denyEnding, denyPoint);
        Transition(nextObject);
        
    }

    public void ChooseSkipPass()
    {
        bool hasChosenPass = ChoiceSystem.instance.choosePass;
        bool notOpened = linkedObject != null && !linkedObject.openedPackage;

        if (notOpened && hasChosenPass)
        {
            GameProgressManager.instance.AddPoint(skipPassEnding, skipPassPoint);
            Debug.Log("Skip after choosing Pass");
            Transition(nextObject);
            
        }

        ChoiceSystem.instance.ClearChoices();
    }

    public void ChooseSkipDeny()
    {
        bool hasChosenDeny = ChoiceSystem.instance.chooseDeny;
        bool notOpened = linkedObject != null && !linkedObject.openedPackage;

        if (notOpened && hasChosenDeny)
        {
            GameProgressManager.instance.AddPoint(skipDenyEnding, skipDenyPoint);
            Debug.Log("Skip after choosing Deny");
            Transition(nextObject);
        }

        ChoiceSystem.instance.ClearChoices();
    }

    private void Transition(GameObject nextObject)
    {
        Debug.Log("Transition triggered");

        if (currentObject != null)
            currentObject.SetActive(false);
        if (nextObject != null)
        {
            nextObject.SetActive(true);
            DayManager.instance.NextPackage();
        }
        else if (DayManager.instance != null)
            DayManager.instance.NextDay();
        else
        {
            EndingManager ending = FindFirstObjectByType<EndingManager>();
            if (ending != null) ending.ShowEnding();
        }
    }
}
