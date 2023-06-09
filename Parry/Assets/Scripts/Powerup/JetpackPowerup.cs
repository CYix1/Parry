using System;
using System.Collections.Generic;
using LevelGeneration;
using UnityEngine;

public class JetpackPowerup : MonoBehaviour
{
    [SerializeField] private List<GameObject> parries;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private float _maxheight = 5.0f;
    [SerializeField] private float timer = 5f;
    private float _speed = 10f;
    private bool _active = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")&&!_active)
        {
            SetActive();
            powerUp.SetActive(false);
            _active = true;
            player.GetComponent<Rigidbody>().useGravity = false;
            foreach (var VARIABLE in gameObject.GetComponentsInChildren<MovingObject>())
            {
                Destroy(VARIABLE);
            }foreach (var VARIABLE in gameObject.GetComponentsInChildren<Renderer>())
            {
                VARIABLE.enabled = false;
            }

            GetComponent<BoxCollider>().enabled=false;
            timer = 5;
        }
    }

   

    void Update()
    {
        
        if (timer <= 0)
        {
            _active = false;
            player.GetComponent<Rigidbody>().useGravity = true;
            if (player.transform.position.y <=1) SetInactive();
        }
        if (_active)
        {
            if(player.transform.position.y <= _maxheight) Move(true);
            timer -= Time.deltaTime;
        }
    }
    public void Move(bool up)
    {
        var pos = player.transform.position;
        if (up)
        {
            if (player.transform.position.y >= _maxheight) return;
            player.transform.position = new Vector3(pos.x, pos.y + _speed * Time.deltaTime, pos.z);
            
        }
        else player.transform.position = new Vector3(pos.x, pos.y + -(_speed * Time.deltaTime), pos.z);
    }
    public void SetActive()
    {
        foreach (var parry in parries)
        {
            parry.SetActive(false);
        }
        parries[2].SetActive(true);
        player.GetComponent<CharacterMovement>().activity = CharacterMovement.Activity.JETPACK;

    }
    public void SetInactive()
    {
        foreach (var parry in parries)
        {
            parry.SetActive(false);
        }
        parries[0].SetActive(true);
        player.GetComponent<CharacterMovement>().activity = CharacterMovement.Activity.RUNNING;
        
        Destroy(gameObject);
        
    }
}
