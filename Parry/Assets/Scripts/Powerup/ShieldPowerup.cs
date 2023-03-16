
using LevelGeneration;
using UnityEngine;

public class ShieldPowerup: MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shield;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var new_pos = player.transform.position;
            new_pos += new Vector3(-4, 0, 0);
            var new_pw=Instantiate(shield.transform, new_pos,Quaternion.identity,player.transform);
            new_pw.gameObject.SetActive(true);
            Destroy(new_pw.GetComponent<MovingObject>());
            Destroy(gameObject);
        }
    }
}
