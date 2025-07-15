using UnityEngine;

public class PackageInteractive : MonoBehaviour
{
    public static PackageInteractive instance;

    [Header("3D Model Viewer")]
    public GameObject modelPrefab;
    public Transform modelSpawnPoint;

    [Header("Dialogue & Object")]
    public DialogueData packageDialogue;
    public ChoiceEvent choiceEvent;

    public bool openedPackage = false;
    public bool isOpen = false;
    public bool isViewingModel = false;

    void Start() => instance = this;

    void OnMouseDown()
    {
        if (DialogueManager.instance.isTalking
            || NoteViewerButton.instance?.isOn == true
            || NewsViewerButton.instance?.isOn == true)
            return;

        Debug.Log("CLICKED: " + gameObject.name);


        if (!isOpen)
        {
            if (ObjectViewer.instance != null && modelPrefab != null)
            {
                ObjectViewer.instance.ShowModel(modelPrefab);
                isViewingModel = true;
            }

            if (packageDialogue != null)
                DialogueManager.instance.StartDialogue(packageDialogue);

            openedPackage = true;
            isOpen = true;
            Debug.Log($"{gameObject.name} opened");
        }
        else
        {

            ObjectViewer.instance?.HideModel();
            isViewingModel = false;
            isOpen = false;
            //openedPackage = false;
            Debug.Log($"{gameObject.name} closed");
        }
    }


    void Update()
    {
        if (isViewingModel && Input.GetKeyDown(KeyCode.E))
        {
            ObjectViewer.instance?.HideModel();
            isViewingModel = false;
            Debug.Log($"{gameObject.name} viewer closed");
        }
    }
}

