using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    [Header("UI Prompt")]
    public GameObject interactPromptUI;

    [Header("Building Folders")]
    public GameObject modernBuildingsFolder;
    public GameObject historicBuildingsFolder;

    private bool isPlayerInRange = false;
    private bool isHistoricShown = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleBuildings();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("player") || other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactPromptUI != null) interactPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("player") || other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactPromptUI != null) interactPromptUI.SetActive(false);
        }
    }

    void ToggleBuildings()
    {
        isHistoricShown = !isHistoricShown;
        if (modernBuildingsFolder != null) modernBuildingsFolder.SetActive(!isHistoricShown);
        if (historicBuildingsFolder != null) historicBuildingsFolder.SetActive(isHistoricShown);
    }
}