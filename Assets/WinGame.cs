using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        winPanel.SetActive(true);
    }
}