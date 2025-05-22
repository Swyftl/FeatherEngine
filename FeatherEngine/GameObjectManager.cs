namespace FeatherEngine;

public class GameObjectManager
{
    private List<IGameObject> _gameObjects;

    public GameObjectManager()
    {
        _gameObjects = new List<IGameObject>();
    }
    
    public void AddNewGameObject(IGameObject gameObject)
    {
        this._gameObjects.Add(gameObject);
    }

    public void RemoveGameObject(IGameObject gameObject)
    {
        this._gameObjects.Remove(gameObject);
    }

    public void ProcessGameObjects(double deltaTime)
    {
        foreach (IGameObject gameObject in _gameObjects)
        {
            gameObject.Process(deltaTime);
        }
    }
}