using UnityEngine;

public class PackageUIController : MonoBehaviour
{
    private PackageManager manager;

    private void Start()
    {
        manager = FindFirstObjectByType<PackageManager>();
        if (manager == null)
        {
            Debug.LogError("PackageManager not found in scene.");
        }
    }

    public void ToggleNote()
    {
        if (manager == null || manager.currentNote == null) return;

        bool isActive = manager.currentNote.activeSelf;
        manager.currentNote.SetActive(!isActive);
        Debug.Log($"Note is now {(isActive ? "Hidden" : "Visible")}");
    }

    public void ToggleNews()
    {
        if (manager == null || manager.currentNews == null) return;

        bool isActive = manager.currentNews.activeSelf;
        manager.currentNews.SetActive(!isActive);
        Debug.Log($"News is now {(isActive ? "Hidden" : "Visible")}");
    }

}
