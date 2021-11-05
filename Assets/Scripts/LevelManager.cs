using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Declarations
    public GameObject currentCheckpoint;
    private PO player;
    public float respawnDelay;
    public HealthManager healthManager;

    // Start is called before the first frame update
    private void Awake()
    {
        //Initializations
        player = FindObjectOfType<PO>();
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called when Player dies
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    //Allows the Respawn code to run along side the rest of the game
    //Disables Player movement and visibility, waits for respawnDelay seconds, 
    //sets Player's location to last checkpoint, resets health, and reenables moevement and visibility
    public IEnumerator RespawnPlayerCo()
    {
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        Debug.Log("Player Respawned");
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;
        player.enabled = true;
        healthManager.ResetHealth();
        healthManager.isDead = false;
        player.GetComponent<Renderer>().enabled = true;
    }
}
