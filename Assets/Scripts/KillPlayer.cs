using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    public LevelManager levelManager;
    // Start is called before the first frame update

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
