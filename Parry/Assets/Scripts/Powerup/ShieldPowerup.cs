
using LevelGeneration;
using Powerup;
using UnityEngine;

public class ShieldPowerup: MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
         
            if (player.GetComponentsInChildren<ShieldPowerup>().Length != 0) return;
         
            var new_pos = player.transform.position;
            new_pos += new Vector3(-2, 0, 0);

            var new_pw=Instantiate(transform, new_pos,Quaternion.identity,player.transform);
            new_pw.gameObject.SetActive(true);
            new_pw.GetComponent<Deflect>().enabled = true;
            new_pw.GetComponent<FlashRed>().enabled = true;

        }
    }
}
