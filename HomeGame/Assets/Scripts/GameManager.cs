using System;
using System.Collections.Generic;
using Imagine.WebAR;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject jerseyPrefab;
    [SerializeField]
    private GameObject customizationUI;
    [SerializeField]
    private GameObject backgroundPanel;
    [SerializeField]
    private GameObject bannerPrefab;
    [SerializeField]
    private GameObject mainscreenUI;
    [SerializeField] 
    private GameObject tracker;
    [SerializeField]
    private GameObject jerseyAr;
    [SerializeField]
    private ImageTracker imageTracker;
    [SerializeField]
    private OnBoarding onboarding;
    [SerializeField]
    private List<GameObject> uiList = new List<GameObject>();

    private List<GameObject> acquiredArtifacts = new List<GameObject>();
    private List<GameObject> acquiredJerseys = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Static instance accessible from anywhere
    public static GameManager Instance { get; private set; }

    private Dictionary<string, GameObject> uiElements = new Dictionary<string, GameObject>();

    void Awake()
    {
        // Check if instance already exists
        if (Instance != null && Instance != this)
        {
            // Destroy duplicate GameManager instances
            Destroy(gameObject);
        }
        else
        {
            // Assign this instance as the singleton instance
            Instance = this;
            // Optional: Persist across scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        tracker.SetActive(false);
        customizationUI.SetActive(false);
        jerseyPrefab.SetActive(false);
        bannerPrefab.SetActive(true);

        foreach (GameObject uiElement in uiList)
        {
            string name = uiElement.name;
            if (!uiElements.ContainsKey(name))
            {
                uiElements.Add(name, uiElement);
            }
            else
            {
                Debug.LogWarning($"UI element {name} already exists in dictionary.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            ToggleCustomizationUI();
        }
    }

    public void ToggleCustomizationUI()
    {
        bool isActive = customizationUI.activeSelf;
        if(!isActive)
        {
            imageTracker.OnTrackingLost("rocks");
        }
        onboarding.HideTutorial();
        jerseyPrefab.SetActive(true);
        customizationUI.SetActive(!isActive);
        backgroundPanel.SetActive(!isActive);
        tracker.SetActive(isActive);
        bannerPrefab.SetActive(isActive);
        mainscreenUI.SetActive(isActive);
    }

    public void AcquireArtifact(GameObject artifact)
    {
        acquiredArtifacts.Add(artifact);
        ShowUI("Artifact PopUp");
        // Add logic to handle acquired artifacts
    }

    public void AcquireJerseys(GameObject jersey)
    {
        acquiredJerseys.Add(jersey);
        // Add logic to handle acquired jerseys
    }

    public void ShowUI(string name)
    {
        if (uiElements.ContainsKey(name))
        {
            uiElements[name].SetActive(true);
        }
        else
        {
            Debug.LogWarning($"UI element {name} not found in dictionary.");
        }
    }

    public void HideUI(string name)
    {
        Debug.Log($"Hiding UI: {name}");
        if (uiElements.ContainsKey(name))
        {
            uiElements[name].SetActive(false);
        }
        else
        {
            Debug.LogWarning($"UI element {name} not found in dictionary.");
        }
    }

    public void TurnOnTracker()
    {
        tracker.SetActive(true);
    }

    public void TurnOffTracker()
    {
        tracker.SetActive(false);
    }

    public void LoseTracking()
    {
        imageTracker.OnTrackingLost("corals");
    }
}
