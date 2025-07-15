using UnityEngine;

public class NewsViewerButton : Model3DViewerButton
{
    public static NewsViewerButton instance;
    public bool isOn;

    void Start() => instance = this;

    void OnMouseDown()
    {
        ToggleModel();
    }
    protected override GameObject GetModelToShow()
    {
        return PackageManager.instance?.currentNews;
    }

    protected override void OnToggle(bool isNowShowing)
    {
        isOn = isNowShowing;
        Debug.Log("News model toggled: " + isNowShowing);
    }
}
