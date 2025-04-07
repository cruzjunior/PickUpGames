using UnityEngine;

public class JerseyAR : MonoBehaviour
{
    [SerializeField] 
    private GameObject customizePopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void OnEnable()
    {
        customizePopup.SetActive(true);
    }
    void OnDisable()
    {
        customizePopup.SetActive(false);
    }
}
