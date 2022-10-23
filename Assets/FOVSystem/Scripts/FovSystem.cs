using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FovSystem : MonoBehaviour
{
    [Header("FOV Settings")] [SerializeField]
    private float detectionRadius = 10f;

    [SerializeField] private float detectionAngle = 90f;
    [SerializeField] private Vector3Value targetValue;

    [Header("FOV Gizmos")]
    [SerializeField] private Color notInAngleColor;
    [SerializeField] private Color inAngleColor;

    private bool _isTargetInAngle;

    void Update()
    {
        CheckForTarget();
    }

    /// <summary>
    /// Gets the direction of target, checks it's in radius. If so, check the dot product so that we can find the target is in FOV angle.
    /// </summary>
    private void CheckForTarget()
    {
        Vector3 selfPosition = transform.position;

        // Get the target position & calculate direction.
        Vector3 direction = targetValue.value - selfPosition;

        // Set the Y position to zero. We dont need that in that case.
        direction.y = 0f;

        // If the target is in radius..
        if (direction.magnitude <= detectionRadius)
        {
            // If the target is in "angle" that we determined.
            if (Vector3.Dot(direction.normalized, transform.forward) > Mathf.Cos(detectionAngle * .5f * Mathf.Deg2Rad))
            {
                // Target is in angle..
                Debug.Log("Target is in angle..");
                _isTargetInAngle = true;
            }
            else
            {
                // Target is in radius  but its not in angle.
                Debug.Log("Target is not in angle..");
                _isTargetInAngle = false;
            }
        }
        else
        {
            _isTargetInAngle = false;
            // Target is not in radius.
        }
    }

#if UNITY_EDITOR
    private void OnGUI()
    {
        string content = _isTargetInAngle ? "Target is in Angle" : "Target is not in angle";
        GUILayout.Label($"<color='black'><size=40> {content} </size></color>");
    }
#endif


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = _isTargetInAngle ? inAngleColor : notInAngleColor;
        Vector3 calculatedDirection = Quaternion.Euler(0f, -detectionAngle * .5f, 0f) * transform.forward;
        Handles.DrawSolidArc(transform.position, Vector3.up, calculatedDirection, detectionAngle, detectionRadius);
    }
#endif
}