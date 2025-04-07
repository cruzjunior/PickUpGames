using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabsManager : MonoBehaviour
{
    [SerializeField]
    private List<Tab> tabs = new List<Tab>();

    [SerializeField]
    private float[] selectedTabHeight = new float[2];
    [SerializeField]
    private bool changeHeight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        foreach (Tab tab in tabs)
        {
            if (tab.isActive)
            {
                tab.tabObject.SetActive(true);
                if(changeHeight)
                {
                    RectTransform rectTransform = tab.button.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, selectedTabHeight[0]);
                }
                //mark button as selected
                tab.button.GetComponent<Button>().Select();
            }
            else
            {
                tab.tabObject.SetActive(false);
                if(changeHeight)
                {
                    RectTransform rectTransform = tab.button.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, selectedTabHeight[1]);
                }
            }
        }
    }

    public void ShowTab(string tabName)
    {
        foreach (Tab tab in tabs)
        {
            if (tab.name == tabName)
            {
                tab.tabObject.SetActive(true);
                tab.isActive = true;
                if(changeHeight)
                {
                    RectTransform rectTransform = tab.button.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, selectedTabHeight[0]);
                }
            }
            else
            {
                tab.tabObject.SetActive(false);
                tab.isActive = false;
                if(changeHeight)
                {
                    RectTransform rectTransform = tab.button.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, selectedTabHeight[1]);
                }
            }
        }
    }
}

[System.Serializable]
public class Tab
{
    public string name;
    public GameObject tabObject;
    public bool isActive = false;
    public Button button;
}
