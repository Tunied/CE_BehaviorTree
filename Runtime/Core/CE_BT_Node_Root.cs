using System.Collections.Generic;

namespace Plugins.CE_BehaviorTree.Runtime
{
    public class CE_BT_Node_Root : I_CE_BT_Node_WithChild
    {
        /// <summary>
        /// 全部的Child节点,用于最后的清理
        /// </summary>
        public List<I_CE_BT_Node> AllChildNodeList;

        /// <summary>
        /// 当前正在执行中,还没有返回结果的节点
        /// - 因为没有Parallel,所以同一时间只会有一个节点Running
        /// - ObserverAbort Tick时候判断当前Running节点是否可以被其打断(1.该节点可以被打断,2.在自己Cache的可打断节点列表中)
        /// </summary>
        public I_CE_BT_Node NowRunningNode;

        /// <summary>
        /// BT是可以嵌套的,如果嵌套执行 那Parent就应该指向嵌套当前BT的Node
        /// </summary>
        public I_CE_BT_Node_WithChild Parent { get; }

        public void OnTrigger() { }

        public void OnEntireTreeFinish() { }

        public void OnChildFinish(I_CE_BT_Node _node, CE_BT_Config.CE_BT_State _finishState)
        {
            //TODO:通知BT当前执行结束.

            AllChildNodeList.ForEach(node => node.OnEntireTreeFinish());
        }


        //对所有可以Abort的子节点进行Tick
        private void AbortCheck_Tick() { }
    }
}