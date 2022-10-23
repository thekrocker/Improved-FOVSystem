using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Assign this to the object that you want to hold its position.
public class Vector3ValueHolder : MonoBehaviour
{
    public Vector3Value valueSo;
    private void Update() => valueSo.value = transform.position;
}
