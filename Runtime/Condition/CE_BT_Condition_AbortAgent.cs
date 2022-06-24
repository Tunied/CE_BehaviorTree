namespace Plugins.CE_BehaviorTree.Runtime
{
    /// <summary>
    /// 创建时候首先尝试Abort当前Node,如果失败则注册到TickManger上
    /// 按设定的间隔去Tick,每次Tick都是尝试一下是否可以Abort
    /// - 当前Running的节点目前可以被打断
    /// - Running的节点层级符合打断要求
    /// </summary>
    public class CE_BT_Condition_AbortAgent
    {
        private CE_BT_Condition_Executor mHost;

        private void OnDispose()
        {
            //将自身从Host身上移除
            mHost.AbortAgent = null;
            //TODO:自身从Tick中卸载
        }
    }
}