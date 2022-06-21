namespace Plugins.CE_BehaviorTree.Runtime
{
    public interface I_CE_BT_Node_WithChild : I_CE_BT_Node
    {
        void OnChildFinish(I_CE_BT_Node _node, CE_BT_Config.CE_BT_State _finishState);
    }
}