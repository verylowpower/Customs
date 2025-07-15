using UnityEngine;

public abstract class Model3DViewerButton : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public ObjectViewer viewer;

    private bool isShowing = false;

    public void ToggleModel()
    {
        isShowing = !isShowing;

        GameObject model = GetModelToShow(); 

        if (isShowing && model != null && viewer != null)
        {
            viewer.ShowModel(model);
        }
        else if (viewer != null)
        {
            viewer.HideModel();
        }

        OnToggle(isShowing);
    }

    protected abstract GameObject GetModelToShow();


    protected virtual void OnToggle(bool isNowShowing) { }
}
