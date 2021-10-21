using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private PO player;
    public float respawnDelay;
    public HealthManager healthManager;
    // Start is called before the first frame update

    private void Awake()
    {
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
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

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
