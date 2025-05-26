namespace FeatherEngine.Managers;

public class NodeManager
{
    private List<INode> _nodes = new List<INode>();
    private IntPtr _renderer;

    public NodeManager(IntPtr renderer)
    {
        this._renderer = renderer;
    }
    
    public void AddNode(INode node)
    {
        _nodes.Add(node);
    }

    public void RemoveNode(INode node)
    {
        _nodes.Remove(node);
    }

    public void RenderNodes()
    {
        foreach (var node in _nodes)
        {
            node.Render(_renderer);
        }
    }

    public void OnQuit()
    {
        foreach (var node in _nodes)
        {
            node.Destroy();
        }
    }
}