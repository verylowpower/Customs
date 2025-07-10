using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    private GameObject note;
    private GameObject news;

    void OnMouseDown()
    {
        if (DialogueManager.instance != null && DialogueManager.instance.isTalking) return;

        // Tìm note và news tương ứng từ PackageManager
        var manager = FindFirstObjectByType<PackageManager>();
        if (manager == null) return;

        foreach (var set in manager.packages)
        {
            if (set.packageObject == this.gameObject) // Kiểm tra kỹ: có đúng object gốc không?
            {
                note = set.noteObject;
                news = set.newsObject;
                break;
            }
        }

        // Bật note và news (nếu có)
        if (note != null)
        {
            bool isActive = note.activeSelf;
            note.SetActive(!isActive);
            Debug.Log($"Note {note.name} is now {(isActive ? "Hidden" : "Visible")}");
        }

        if (news != null)
        {
            bool isActive = news.activeSelf;
            news.SetActive(!isActive);
            Debug.Log($"News {news.name} is now {(isActive ? "Hidden" : "Visible")}");
        }
    }
}
