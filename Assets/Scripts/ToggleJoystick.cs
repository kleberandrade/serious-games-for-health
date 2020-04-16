using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleJoystick : MonoBehaviour
{

    public void toggleJoystick(bool enable)
    {
        GetComponent<Canvas>().enabled = enable;
    }

}
