using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject settingsMenu;

    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
    }

    public void HideSettings()
    {
        settingsMenu.SetActive(false);
    }

}
