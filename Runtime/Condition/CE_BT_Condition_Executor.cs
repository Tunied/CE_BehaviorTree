using System.Collections.Generic;
using UnityEngine;

namespace Plugins.CE_BehaviorTree.Runtime
{
    public class CE_BT_Condition_Executor : I_CE_BT_Node
    {
        public I_CE_BT_Node_WithChild Parent { get; }

        /// <summary>
        /// 当前节点需要检测的所有条件
        /// </summary>
        public List<I_CE_BT_Condition> mAllConditionList;

        public CE_BT_Config.CE_BT_FinishStrategy Strategy;

        public bool IsObserverAbort;

        /// <summary>
        /// 打断后跳转到的节点
        /// </summary>
        public I_CE_BT_Node AbortToNode;

        public CE_BT_Condition_AbortAgent AbortAgent;

        public bool IsUseTickForCheckAbort;

        public float TickAbortCheckGap;

        public void OnTrigger()
        {
            //TODO:检查一遍所有的Condition 按返回策略返回
        }

        public void OnEntireTreeFinish()
        {
            //TODO:取消注册Tick监听
        }


        /// <summary>
        /// Tick检测可否Abort当前RunningNode
        /// </summary>
        /// <returns></returns>
        public bool Tick_AbortChecker() { return false; }
    }
}