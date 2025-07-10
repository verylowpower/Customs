using UnityEngine;

public class PackageManager : MonoBehaviour
{
    [System.Serializable]
    public class PackageSet
    {
        public GameObject packageObject;
        public GameObject noteObject;
        public GameObject newsObject;
    }

    public PackageSet[] packages;

    [HideInInspector] public GameObject currentNote;
    [HideInInspector] public GameObject currentNews;

    public void AutoAssignPackages(GameObject dayRoot)
    {
        if (dayRoot == null)
        {
            Debug.LogError("dayRoot is null!");
            return;
        }

        var list = new System.Collections.Generic.List<PackageSet>();

        foreach (Transform package in dayRoot.transform)
        {
            var canvas = package.Find("Canvas Full Screen");
            if (canvas == null) continue;

            var note = canvas.Find("Note")?.gameObject;
            var news = canvas.Find("News")?.gameObject;

            list.Add(new PackageSet
            {
                packageObject = package.gameObject,
                noteObject = note,
                newsObject = news
            });
        }

        packages = list.ToArray();
        Debug.Log("Auto-assigned " + packages.Length + " packages from " + dayRoot.name);
    }

    public void SetCurrentPackage(GameObject activePackage)
    {
        PackageSet foundSet = null;

        foreach (var set in packages)
        {
            bool isActive = set.packageObject == activePackage;
            set.packageObject.SetActive(isActive);
            if (isActive)
                foundSet = set;
        }

        if (foundSet != null)
        {
            currentNote = foundSet.noteObject;
            currentNews = foundSet.newsObject;

            if (currentNote != null) currentNote.SetActive(false);
            if (currentNews != null) currentNews.SetActive(false);

            Debug.Log($"[PackageManager] Switched to package {foundSet.packageObject.name}");
            Debug.Log($"Note Object: {currentNote?.name}, in Scene: {currentNote?.scene.name}");
            Debug.Log($"News Object: {currentNews?.name}, in Scene: {currentNews?.scene.name}");
        }
        else
        {
            currentNote = null;
            currentNews = null;
            Debug.LogWarning("No matching package found for: " + activePackage.name);
        }
    }
}
