namespace FeatherEngine;

public interface INode
{
    void Init(IntPtr window, IntPtr renderer);
    void Update(float deltaTime);
    void Render(IntPtr renderer);
    void Destroy();
}