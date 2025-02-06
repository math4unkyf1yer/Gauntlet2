using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadPage : MonoBehaviour
{
    public GameObject Menu;
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TryAgain()
    {
        Menu.SetActive(true);
        GameOver.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
