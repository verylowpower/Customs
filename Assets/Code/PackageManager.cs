using System.Collections.Generic;
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
    public static PackageManager instance;

    [HideInInspector] public GameObject currentNote;
    [HideInInspector] public GameObject currentNews;

   
    private GameObject currentPackage;

    void Start() => instance = this;

    public void AutoAssignPackages(GameObject dayRoot)
    {
        if (dayRoot == null)
        {
            Debug.LogError("dayRoot is null!");
            return;
        }

        var list = new List<PackageSet>();

        foreach (Transform package in dayRoot.transform)
        {
            var anchor = package.GetComponent<PackageAnchor>();
            if (anchor == null)
            {
                Debug.LogWarning("Package missing PackageAnchor: " + package.name);
                continue;
            }

            list.Add(new PackageSet
            {
                packageObject = package.gameObject,
                noteObject = anchor.noteObject,
                newsObject = anchor.newsObject
            });
        }

        packages = list.ToArray();
        Debug.Log("Auto-assigned " + packages.Length + " packages from " + dayRoot.name);
    }

    public void SetCurrentPackage(GameObject activePackage)
    {
      
        if (activePackage == currentPackage)
        {
            Debug.Log($"[PackageManager] Package {activePackage.name} is already active, skipping.");
            return;
        }

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
            currentPackage = foundSet.packageObject;
            currentNote = foundSet.noteObject;
            currentNews = foundSet.newsObject;

            if (currentNote != null) currentNote.SetActive(false);
            if (currentNews != null) currentNews.SetActive(false);

            Debug.Log($"[PackageManager] Switched to package {foundSet.packageObject.name}");
        }
        else
        {
            currentNote = null;
            currentNews = null;
            currentPackage = null;
            Debug.LogWarning("No matching package found for: " + activePackage.name);
        }
    }
}
