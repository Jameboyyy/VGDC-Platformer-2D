using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //Declarations
    public int maxPlayerHealth;
    public static int playerHealth;
    private LevelManager levelManager;
    Text text;
    public bool isDead;

    //Initializations
    private void Awake()
    {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Player is alive at the start of the game
        isDead = false;   
    }

    // Update is called once per frame
    void Update()
    {
        //Returns true if player runs out of health and they are not already dead
        //Calls RespawnPlayer() from LevelManager script
        if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }
        //Updates health display
        text.text = "" + playerHealth;
    }

    //Damages Player
    //Static function, so can be called from any other script with out referencing this one
    public static void HurtPlayer(int damage)
    {
        playerHealth -= damage;
    }

    //Sets Player's health to full
    public void ResetHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
