using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject healthPanel;
    public GameObject player;
    public GameObject level1;
    public GameObject chooseChracter;
    public GameObject startButton;
    public SpriteRenderer changePlayerColor;

    [Header("Script")]
    private Health healthScript;
    private TopDownMovement movementScript;
    public void OnClickStart()
    {
        healthScript = player.GetComponent<Health>();
        movementScript = player.GetComponent<TopDownMovement>();
        chooseChracter.SetActive(true);
        startButton.SetActive(false);
    }
    public void OnClickYellow()
    {
        OnClickCharacter();
        changePlayerColor.color = Color.yellow;
        movementScript.isOrange = true;
    }
    public void OnClickBlue()
    {
        OnClickCharacter();
        changePlayerColor.color = Color.blue;
        healthScript.health += 50;
    }
    public void OnClickGreen()
    {
        OnClickCharacter();
        changePlayerColor.color = Color.green;
        movementScript.moveSpeed += 0.5f;
    }
    public void OnClickWhite()
    {
        OnClickCharacter();
        changePlayerColor.color = Color.white;
        movementScript.isWhite = true;
    }
    public void OnClickCharacter()
    {
        healthPanel.SetActive(true);
        player.SetActive(true);
        level1.SetActive(true);
        gameObject.SetActive(false);
    }
}
