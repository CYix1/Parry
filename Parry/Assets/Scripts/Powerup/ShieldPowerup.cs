
using UnityEngine;

public class ShieldPowerup: MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shield;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Debug.Log("dao");
        }
    }
}
