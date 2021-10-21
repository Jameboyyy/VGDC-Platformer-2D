using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;
    public static int playerHealth;
    private LevelManager levelManager;
    Text text;
    public bool isDead;

    private void Awake()
    {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }

        text.text = "" + playerHealth;
    }

    public static void HurtPlayer(int damage)
    {
        playerHealth -= damage;
    }

    public void ResetHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
