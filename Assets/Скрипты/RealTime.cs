using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTime : MonoBehaviour
{
	public TextMesh txt;
    void FixedUpdate()
    {
		txt.text = DateTime.Now.ToLongTimeString();
    }
}
