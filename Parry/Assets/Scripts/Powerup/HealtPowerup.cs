
using UnityEngine;

public class HealtPowerup :MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameData.instance.health += 2;
            Debug.Log("Add Health");
            UIOverlay.UIUpdate.Invoke();
            Destroy(gameObject);
        }
    }
}
