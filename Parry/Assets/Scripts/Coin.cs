using UnityEngine;

// simple collectable. Increases COIN COUNTER in GameData
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (!IsPlayer(other)) return;
        
        Destroy(gameObject);
        
        GameData.instance.coins++;
    }

    private bool IsPlayer(Collider other)
    {
        return other.CompareTag("Player");
    }
}