namespace Plugins.CE_BehaviorTree.Runtime
{
    public interface I_CE_BT_Node
    {
        I_CE_BT_Node_WithChild Parent { get; }
        void OnTrigger();
    }
}