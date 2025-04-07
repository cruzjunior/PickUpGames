using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class OnBoarding : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> onboardingItems = new List<GameObject>();
    [SerializeField]
    private FeatureCycler featureCycler;
    [SerializeField]
    private List<GameObject> tutorialItems = new List<GameObject>();
    [SerializeField]
    private GameObject onboardingPanelPrefab;
    [SerializeField]
    private float timeToShow = 5f;
    [SerializeField]
    private GameObject mainMenuPrefab;


    private int currentItemIndex = 0;
    private bool isTutorial = false;
    private float elapsedTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        onboardingItems[currentItemIndex].SetActive(true);
        onboardingPanelPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeToShow)
            {
                ShowTutorialItems();
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShowTutorialItems();
            }
        }
    }
    
    public void NextOnboardingItem()
    {
        if (onboardingItems[currentItemIndex].name == "Features" && featureCycler.Next())
        {
            return;
        }
        onboardingItems[currentItemIndex].SetActive(false);
        currentItemIndex++;
        if (onboardingItems.Count > currentItemIndex)
        {
            onboardingItems[currentItemIndex].SetActive(true);
        }
        else
        {
            GameManager.Instance.TurnOnTracker();
            onboardingPanelPrefab.SetActive(false);
            mainMenuPrefab.SetActive(true);
            currentItemIndex = 0;
            tutorialItems[currentItemIndex].SetActive(true);
            isTutorial = true;
        }
        
    }
    private void ShowTutorialItems()
    {
        tutorialItems[currentItemIndex].SetActive(false);
        currentItemIndex++;
        if (tutorialItems.Count > currentItemIndex)
        {
            tutorialItems[currentItemIndex].SetActive(true);
        }
        else
        {
            currentItemIndex = 0;
            isTutorial = false;
        }
        elapsedTime = 0f;
    }

    public void HideTutorial()
    {
        tutorialItems[currentItemIndex].SetActive(false);
        currentItemIndex = 0;
        isTutorial = false;
    }
}
