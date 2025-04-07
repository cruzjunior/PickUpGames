using UnityEngine;

public class UploadJersey : MonoBehaviour
{
    [SerializeField]
    private GameObject permissionPopup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        permissionPopup.SetActive(false);
    }

    public void OpenPermissionPopup()
    {
        permissionPopup.SetActive(true);
    }

    public void ClosePermissionPopup()
    {
        permissionPopup.SetActive(false);
    }
}
