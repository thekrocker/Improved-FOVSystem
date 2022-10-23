# Improved-FOVSystem
 a field of view detector for objects.
 
 ## How It Works
 
 - First, it calculates the direction to target like this. I created a scriptable object value system that make an easy access to positions in game.
 
           Vector3 selfPosition = transform.position;
           // Get the target position & calculate direction.
           Vector3 direction = targetValue.value - selfPosition;
           
- Then we calculate the distance by magnitude. (You can also use Vector3.Distance here.)

           if (direction.magnitude <= detectionRadius) { }
                
- If it is in radius, we calculate the dot product of direction and our forward. So that we can learn if the target is in our angle.

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

- And we create a gizmos to see visually in edit-mode. It just basically creates and arc with angle/radius

           #if UNITY_EDITOR
               private void OnDrawGizmos()
               {
                   Handles.color = _isTargetInAngle ? inAngleColor : notInAngleColor;
                   Vector3 calculatedDirection = Quaternion.Euler(0f, -detectionAngle * .5f, 0f) * transform.forward;
                   Handles.DrawSolidArc(transform.position, Vector3.up, calculatedDirection, detectionAngle, detectionRadius);
               }
           #endif


 ![Fov System](https://media1.giphy.com/media/VtjMuIIMlHL93VbbXI/giphy.gif?cid=790b761125884bf5c532142d8d2c95b88fd909f7f4369242&rid=giphy.gif&ct=g)
