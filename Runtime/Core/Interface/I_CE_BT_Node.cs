namespace Plugins.CE_BehaviorTree.Runtime
{
    public interface I_CE_BT_Node
    {
        I_CE_BT_Node_WithChild Parent { get; }
        
        void OnTrigger();

        /// <summary>
        /// 当前BT整体执行完毕,每个Node执行自身的清理
        /// </summary>
        void OnEntireTreeFinish();
    }
}