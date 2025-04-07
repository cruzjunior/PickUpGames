using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JerseyCustomization : MonoBehaviour
{
    [SerializeField]
    private Material jerseyMaterial;
    [SerializeField]
    private List<Color> colors = new List<Color>();
    [SerializeField]
    private GameObject jerseyPrefab;
    [SerializeField]
    private Camera nameNumberCamera;
    [SerializeField]
    private RenderTexture nameNumberTexture;
    [SerializeField]
    private TMP_Text nameText;
    [SerializeField]
    private TMP_Text numberText;
    [SerializeField]
    private TMP_InputField nameInputField;
    [SerializeField]
    private TMP_Dropdown numberDropdown;
    [SerializeField] 
    private List<TMP_FontAsset> fontAsset;

    private Coroutine rotationCoroutine;
    private float targetAngle = 180f;

    public void TurnOnCamera()
    {
        nameText.text = nameInputField.text;
        // check if the camera is already enabled
        if (nameNumberCamera.GetComponent<Camera>().enabled)
        {
            return;
        }
        nameNumberCamera.GetComponent<Camera>().enabled = true;
    }

    IEnumerator TurnOffCamera()
    {
        yield return new WaitForEndOfFrame();
        nameNumberCamera.GetComponent<Camera>().enabled = false;
    }

    public void ChangeFont(int index)
    {
        nameText.font = fontAsset[index];
        numberText.font = fontAsset[index];
    }

    public void ChangeText()
    {
        TurnOnCamera();
        nameText.text = nameInputField.text;
        numberText.text = numberDropdown.options[numberDropdown.value].text;

        jerseyMaterial.SetTexture("_RenderTexture", nameNumberTexture);
        StartCoroutine(TurnOffCamera());

    }
    public void ChangePrimaryColour(int index)
    {
        jerseyMaterial.SetColor("_PrimaryColour", colors[index]);
    }
    public void ChangeSecondaryColour(int index)
    {
        jerseyMaterial.SetColor("_SecondaryColour", colors[index]);
    }
    public void ChangeDetailColour(int index)
    {
        jerseyMaterial.SetColor("_DetailColour", colors[index]);
    }

    public void ChangePattern(Texture pattern)
    {
        jerseyMaterial.SetTexture("_MainTex", pattern);
    }

    public void RotateJersey()
    {
        if (targetAngle == 0f)
        {
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
            }
            rotationCoroutine = StartCoroutine(RotateJerseyCoroutine(180f));
            targetAngle = 180f;
        }
        else
        {
            if (rotationCoroutine != null)
            {
                StopCoroutine(rotationCoroutine);
            }
            rotationCoroutine = StartCoroutine(RotateJerseyCoroutine(0f));
            targetAngle = 0f;
        }
    }

    IEnumerator RotateJerseyCoroutine(float angle)
    {
        Quaternion startRotation = jerseyPrefab.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(90, angle, 0);
        float time = 0f;
        while (time < 1f)
        {
            jerseyPrefab.transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            time += Time.deltaTime;
            yield return null;
        }
        jerseyPrefab.transform.rotation = endRotation;
    }
}
