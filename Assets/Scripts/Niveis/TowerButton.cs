using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public int Index;
    public SetTower setscr;

    public void OnClick()
    {
        setscr.Selected = Index;
    }
}
