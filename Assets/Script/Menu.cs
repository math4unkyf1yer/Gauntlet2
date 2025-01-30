using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject healthPanel;
    public GameObject player;
    public GameObject level1;
    public void OnClickStart()
    {
        healthPanel.SetActive(true);
        player.SetActive(true);
        level1.SetActive(true);
        gameObject.SetActive(false);
    }
}
