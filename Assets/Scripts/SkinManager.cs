 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer gb;
    public List<Sprite> skins = new List<Sprite> ();
    public int selectedSkin = 0;
    public GameObject playerSkin;


    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        gb.sprite = skins[selectedSkin];
    }


    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Count -1;
        }
        gb.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay 1");
    }

}
