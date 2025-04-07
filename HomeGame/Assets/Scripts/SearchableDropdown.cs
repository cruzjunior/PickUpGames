using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SearchableDropdown : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] GameObject dropdownPanel;
    [SerializeField] GameObject optionButtonPrefab;
    [SerializeField] Transform optionListParent;

    [SerializeField] List<string> allOptions = new List<string> { "Apple", "Orange", "Banana", "Grape" };
    [SerializeField] JerseyCustomization jerseyCustomization; // Assuming this is a scriptable object or similar that holds the options
    List<GameObject> currentButtons = new List<GameObject>();
 private bool dropdownOpen = false;

    private void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
        inputField.onSelect.AddListener(_ => ShowDropdown());

        dropdownPanel.SetActive(false);
    }

    private void Update()
    {
        if (dropdownOpen && Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIElement(dropdownPanel) && !IsPointerOverUIElement(inputField.gameObject))
            {
                HideDropdown();
            }
        }
    }

    private bool IsPointerOverUIElement(GameObject target)
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, results);

        foreach (var result in results)
        {
            if (result.gameObject == target || result.gameObject.transform.IsChildOf(target.transform))
                return true;
        }

        return false;
    }

    private void OnInputChanged(string input)
    {
        if (!dropdownOpen)
            ShowDropdown();

        FilterOptions(input);
    }

    private void ShowDropdown()
    {
        dropdownPanel.SetActive(true);
        dropdownOpen = true;
        FilterOptions(inputField.text); // Show all options if input is empty
    }

    private void HideDropdown()
    {
        dropdownPanel.SetActive(false);
        dropdownOpen = false;
        ClearButtons();
    }

    private void FilterOptions(string input)
    {
        ClearButtons();

        foreach (string option in allOptions)
        {
            if (option.ToLower().Contains(input.ToLower()))
            {
                GameObject btnObj = Instantiate(optionButtonPrefab, optionListParent);
                TMP_Text btnText = btnObj.GetComponentInChildren<TMP_Text>();
                btnText.text = option;

                btnObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    inputField.text = option;
                    HideDropdown();
                    jerseyCustomization.ChangeText();
                });

                currentButtons.Add(btnObj);
            }
        }
    }

    private void ClearButtons()
    {
        foreach (var btn in currentButtons)
            Destroy(btn);

        currentButtons.Clear();
    }

}
