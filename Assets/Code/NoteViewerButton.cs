using UnityEngine;

public class NoteViewerButton : Model3DViewerButton
{
    public static NoteViewerButton instance;
    public bool isOn;

    void Start() => instance = this;

    void OnMouseDown()
    {
        ToggleModel();
    }

    protected override GameObject GetModelToShow()
    {
        return PackageManager.instance?.currentNote;
    }

    protected override void OnToggle(bool isNowShowing)
    {
        isOn = isNowShowing;
        Debug.Log("Note model toggled: " + isNowShowing);
    }
}
