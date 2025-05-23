# Feather Engine
Feather engine is a lightweight game engine/framework made for use with c#, made with Raylib.

## How does it work
The engine is made using a system of different types that give the functionality of the class that you have made.

```C#
using FeatherEngine;

public class Player: IRenderable, IGameObject 
{
    
}
```

Above I have assigned Renderable and GameObject. which allows it to be rendered, and for it to have a function called each frame.

## Current Features
- [x] Input Management
- [ ] Scenes System
- [x] Rendering System
