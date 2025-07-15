using UnityEngine;
using System.Collections.Generic;

public class DayManager : MonoBehaviour
{
    public static DayManager instance;

    public int currentDay = 0;
    public List<DayData> days;
    private GameObject currentDayObject;
    private PackageManager packageManager;

    private int packageIndex = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        packageManager = GameObject.FindWithTag("PackageManager")?.GetComponent<PackageManager>();

        if (packageManager == null)
        {
            Debug.LogError("PackageManager not found in scene.");
            return;
        }

        LoadDay(currentDay);
    }

    public void LoadDay(int dayIndex)
    {
        if (dayIndex < 0 || dayIndex >= days.Count) return;

        if (currentDayObject != null)
            Destroy(currentDayObject);

        DayData dayData = days[dayIndex];

        if (dayData.dayPrefab != null)
        {
            currentDayObject = Instantiate(dayData.dayPrefab);
            currentDayObject.name = dayData.dayPrefab.name;

            packageManager.AutoAssignPackages(currentDayObject);

            if (packageManager.packages.Length > 0)
            {
                packageManager.SetCurrentPackage(packageManager.packages[0].packageObject);
            }

            Debug.Log("Loaded Day: " + dayIndex + " with " + packageManager.packages.Length + " packages.");
        }
        else
        {
            Debug.LogError("Day prefab is missing in DayData!");
        }
    }

    public void NextDay()
    {
        currentDay++;
        if (currentDay < days.Count)
        {
            LoadDay(currentDay);
        }
        else
        {
            Debug.Log("No more days. Showing ending...");
            EndingManager.instance.ShowEnding();
        }
    }

    public void NextPackage()
    {
        if (packageManager == null || packageManager.packages.Length == 0) return;

        packageIndex = (packageIndex + 1) % packageManager.packages.Length;
        packageManager.SetCurrentPackage(packageManager.packages[packageIndex].packageObject);
    }


}
