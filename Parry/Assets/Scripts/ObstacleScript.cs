
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.instance.health--;
            if (GameData.instance.health <= 0)
            {
                SceneManager.LoadScene(name);
            }
        }
    }
}
