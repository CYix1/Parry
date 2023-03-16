
using System;
using LevelGeneration;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class PowerupSpawner : MonoBehaviour
{
    public Transform[] positions;
    public GameObject[] powerups;
    public float spawnintervall=5f;
    [SerializeField]private float timer;

    public void SpawnPowerup()
    {
        Debug.Log("SPAWENOIAENFAs");
        var pw = powerups[Random.Range(0, powerups.Length)];
        var new_pw=Instantiate(pw.transform, positions[Random.Range(0,positions.Length)].position,Quaternion.identity);
        new_pw.AddComponent<MovingObject>();
        new_pw.gameObject.SetActive(true);
    }


    private void Update()
    {

        timer += Time.deltaTime;
        if (timer > spawnintervall)
        {   
            SpawnPowerup();
            timer = 0;
        }
    }
}
