using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Clone : MonoBehaviour
{
    public void Copy<T>(Transform position) where T : Component
    {
        Clone Instance = Instantiate(this,position);

        // position and reparent
        
    }
}