namespace FeatherEngine;

public class RenderManager
{
    
    private List<IRenderable> renderList = new List<IRenderable>();
    
    public void Render()
    {
        foreach (var item in renderList)
        {
            item.Draw();
        }
    }

    public void AddRenderItem(IRenderable item)
    {
        renderList.Add(item);
    }
}