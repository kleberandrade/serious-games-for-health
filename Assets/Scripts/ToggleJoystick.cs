﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleJoystick : MonoBehaviour
{

    public void toggleJoystick()
    {
        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
    }

}
