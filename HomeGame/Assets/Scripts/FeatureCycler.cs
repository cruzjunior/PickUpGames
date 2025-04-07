using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FeatureCycler : MonoBehaviour
{
    [SerializeField]
    private ScriptableFeatures scriptableFeatures;
    [SerializeField]
    TMP_Text nameText;
    [SerializeField]
    TMP_Text descriptionText;
    [SerializeField]
    TMP_Text flavourTextText;
    [SerializeField]
    TMP_Text progress;

    private int currentFeatureIndex = 0;

    void Start()
    {
        if (scriptableFeatures.features.Count > 0)
        {
            nameText.text = scriptableFeatures.features[currentFeatureIndex].name;
            descriptionText.text = scriptableFeatures.features[currentFeatureIndex].description;
            flavourTextText.text = scriptableFeatures.features[currentFeatureIndex].flavourText;
            progress.text = scriptableFeatures.features[currentFeatureIndex].progressText;
        }
    }

    public bool Next()
    {
        currentFeatureIndex++;
        if (currentFeatureIndex < scriptableFeatures.features.Count)
        {
            nameText.text = scriptableFeatures.features[currentFeatureIndex].name;
            descriptionText.text = scriptableFeatures.features[currentFeatureIndex].description;
            flavourTextText.text = scriptableFeatures.features[currentFeatureIndex].flavourText;
            progress.text = scriptableFeatures.features[currentFeatureIndex].progressText;

            return true;
        }
        
        return false;
    }
}
