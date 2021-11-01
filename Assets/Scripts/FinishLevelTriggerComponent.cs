using UnityEngine;

public class FinishLevelTriggerComponent : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(playerTag)) return;
        
        GameManager.Instance.UpdateLevel();
    }
}
