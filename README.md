# Improved-FOVSystem
 a field of view detector for objects.
 
 ## How It Works
 
 - First, it calculates the direction to target like this. I created a scriptable object value system that make an easy access to positions in game.
 
           Vector3 selfPosition = transform.position;
           // Get the target position & calculate direction.
           Vector3 direction = targetValue.value - selfPosition;
 
 ![Fov System](https://media1.giphy.com/media/VtjMuIIMlHL93VbbXI/giphy.gif?cid=790b761125884bf5c532142d8d2c95b88fd909f7f4369242&rid=giphy.gif&ct=g)
