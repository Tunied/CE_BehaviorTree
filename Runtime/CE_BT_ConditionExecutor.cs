using System.Collections.Generic;
using UnityEngine;

namespace Plugins.CE_BehaviorTree.Runtime
{
    public class CE_BT_ConditionExecutor : I_CE_BT_Node
    {
        public I_CE_BT_Node_WithChild Parent { get; }

        /// <summary>
        /// 当前节点需要检测的所有条件
        /// </summary>
        public List<I_CE_BT_Condition> mAllConditionList;

        public CE_BT_Config.CE_BT_FinishStrategy Strategy;

        public bool IsObserverAbort;

        /// <summary>
        /// 打断后跳转到的节点GUID
        /// </summary>
        public string AbortToNode_GUID;

        public void OnTrigger()
        {
            //TODO:检查一遍所有的Condition 按返回策略返回
        }

        public bool Tick_AbortChecker() { return false; }
    }
}