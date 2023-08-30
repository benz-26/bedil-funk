using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win3 : MonoBehaviour
{
    public static Win3 instance;


    private void Awake()
    {
        instance = this;
    }

    public void Winner1Player()
    {
        SceneManager.LoadScene("Win Level");
    }
}
