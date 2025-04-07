using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField]
    private float timeToAcquire = 2f;
    [SerializeField]
    private GameObject artifactParent;
    private float elapsedTime = 0f;
    
    void OnEnable()
    {
        elapsedTime = 0f;
        // artifactParent.SetActive(true);
        // gameObject.transform.SetParent(artifactParent.transform);
        // GameManager.Instance.LoseTracking();
    }

    public void ArtifactFound()
    {
        if(!gameObject.transform.parent.gameObject.activeSelf)
        {
            return;
        }
        artifactParent.SetActive(true);
        gameObject.transform.SetParent(artifactParent.transform);
        GameManager.Instance.LoseTracking();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeToAcquire)
        {
            GameManager.Instance.AcquireArtifact(gameObject);
            gameObject.SetActive(false);
        }
    }
}
