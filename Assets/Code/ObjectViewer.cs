using UnityEngine;

public class ObjectViewer : MonoBehaviour
{
    public GameObject modelPrefab; 
    private GameObject spawnedModel;

    public Transform spawnPoint;  
    private bool isRotating = false;
    private Vector3 previousMousePosition;
    public static ObjectViewer instance;

    void Start() => instance = this;

    void Update()
    {
        if (spawnedModel != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isRotating = true;
                previousMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isRotating = false;
            }

            if (isRotating)
            {
                Vector3 delta = Input.mousePosition - previousMousePosition;
                previousMousePosition = Input.mousePosition;
                spawnedModel.transform.Rotate(Vector3.up, -delta.x, Space.World);
                spawnedModel.transform.Rotate(Vector3.right, delta.y, Space.World);
            }
        }
    }

    public void ShowModel(GameObject prefab)
    {
        HideModel();

        if (prefab == null || spawnPoint == null)
        {
            Debug.LogWarning("Missing model or spawnPoint.");
            return;
        }

        
        spawnedModel = Instantiate(prefab);

      
        spawnedModel.SetActive(true);

       
        spawnedModel.transform.SetParent(spawnPoint, false);
        
        Debug.Log("Pivot at: " + spawnedModel.transform.position + " | Mesh bounds center: " + spawnedModel.GetComponentInChildren<MeshRenderer>().bounds.center);

     
        spawnedModel.transform.localPosition = Vector3.zero;
        spawnedModel.transform.localRotation = Quaternion.identity;
    }

    public void HideModel()
    {
        if (spawnedModel != null)
        {
            Destroy(spawnedModel);
            spawnedModel = null;
        }
    }
}
