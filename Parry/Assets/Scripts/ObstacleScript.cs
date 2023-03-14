
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameData.instance.health--;
            Debug.Log("Lost Health");
            if (GameData.instance.health <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
