using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    public Controls controls;


   public void ChangeJump(int val)
    {
        if (val == 0)
        {
            controls.Jump = KeyCode.W;
        }
        else if (val == 1)
        {
            controls.Jump = KeyCode.S;
        }
        else if (val == 2)
        {
            controls.Jump = KeyCode.Space;
        }
        else if (val == 3)
        {
            controls.Jump = KeyCode.UpArrow;
        }
        else if (val == 4)
        {
            controls.Jump = KeyCode.DownArrow;
        }
        else if (val == 5)
        {
            controls.Jump = KeyCode.LeftArrow;
        }
        else if (val == 6)
        {
            controls.Jump = KeyCode.RightArrow;
        }
        else if (val == 7)
        {
            controls.Jump = KeyCode.A;
        }
        else if (val == 8)
        {
            controls.Jump = KeyCode.D;
        }
        else if (val == 9)
        {
            controls.Jump = KeyCode.I;
        }
        else if (val == 10)
        {
            controls.Jump = KeyCode.K;
        }
        else if (val == 11)
        {
            controls.Jump = KeyCode.L;
        }
        else if (val == 12)
        {
            controls.Jump = KeyCode.S;
        }
        else if (val == 13)
        {
            controls.Jump = KeyCode.J;
        }
    }
    public void ChangeRoll(int val)
    {
        if (val == 0)
        {
            controls.Roll = KeyCode.W;
        }
        else if (val == 1)
        {
            controls.Roll = KeyCode.S;
        }
        else if (val == 2)
        {
            controls.Roll = KeyCode.Space;
        }
        else if (val == 3)
        {
            controls.Roll = KeyCode.UpArrow;
        }
        else if (val == 4)
        {
            controls.Roll = KeyCode.DownArrow;
        }
        else if (val == 5)
        {
            controls.Roll = KeyCode.LeftArrow;
        }
        else if (val == 6)
        {
            controls.Roll = KeyCode.RightArrow;
        }
        else if (val == 7)
        {
            controls.Roll = KeyCode.A;
        }
        else if (val == 8)
        {
            controls.Roll = KeyCode.D;
        }
        else if (val == 9)
        {
            controls.Roll = KeyCode.I;
        }
        else if (val == 10)
        {
            controls.Roll = KeyCode.K;
        }
        else if (val == 11)
        {
            controls.Roll = KeyCode.L;
        }
        else if (val == 12)
        {
            controls.Roll = KeyCode.S;
        }
        else if (val == 13)
        {
            controls.Roll = KeyCode.J;
        }
    }
    public void ChangeDestroy(int val)
    {
        if (val == 0)
        {
            controls.Shoot = KeyCode.W;
        }
        else if (val == 1)
        {
            controls.Shoot = KeyCode.S;
        }
        else if (val == 2)
        {
            controls.Shoot = KeyCode.Space;
        }
        else if (val == 3)
        {
            controls.Shoot = KeyCode.UpArrow;
        }
        else if (val == 4)
        {
            controls.Shoot = KeyCode.DownArrow;
        }
        else if (val == 5)
        {
            controls.Shoot = KeyCode.LeftArrow;
        }
        else if (val == 6)
        {
            controls.Shoot = KeyCode.RightArrow;
        }
        else if (val == 7)
        {
            controls.Shoot = KeyCode.A;
        }
        else if (val == 8)
        {
            controls.Shoot = KeyCode.D;
        }
        else if (val == 9)
        {
            controls.Shoot = KeyCode.I;
        }
        else if (val == 10)
        {
            controls.Shoot = KeyCode.K;
        }
        else if (val == 11)
        {
            controls.Shoot = KeyCode.L;
        }
        else if (val == 12)
        {
            controls.Shoot = KeyCode.S;
        }
        else if (val == 13)
        {
            controls.Shoot = KeyCode.J;
        }
    }
}
