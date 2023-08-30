using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win1 : MonoBehaviour
{
    public static Win1 instance;


    private void Awake()
    {
        instance = this;
    }

    public void Winner1Player()
    {
        SceneManager.LoadScene("Next Level 1");
    }


}
