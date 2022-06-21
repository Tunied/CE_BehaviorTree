using System.Collections.Generic;
using UnityEngine;

namespace Plugins.CE_BehaviorTree.Runtime
{
    /// <summary>
    /// 从左往右顺序执行所有子节点
    /// - 任何一个节点返回Failure则直接返回Failure
    /// - 所有节点执行完毕则返回Success
    /// </summary>
    public class CE_BT_Sequencer :I_CE_BT_Node_WithChild
    {
        public I_CE_BT_Node_WithChild Parent { get; private set; }


        private List<I_CE_BT_Node> mAllChildList;

        private int mNextLoopIndex;

        public void Initialize() { mAllChildList = new List<I_CE_BT_Node>(); }


        public void OnReset() { mNextLoopIndex = 0; }

        public void OnTrigger() { TryToTriggerNext(); }

        public void OnChildFinish(I_CE_BT_Node _node, CE_BT_Config.CE_BT_State _finishState)
        {
            mNextLoopIndex = GetChildIndex(_node) + 1;
            if (_finishState == CE_BT_Config.CE_BT_State.Success)
            {
                TryToTriggerNext();
            }
            else if (_finishState == CE_BT_Config.CE_BT_State.Failure)
            {
                Parent.OnChildFinish(this, CE_BT_Config.CE_BT_State.Failure);
            }
            else
            {
                //节点的返回结果只能是Success或者Failure
                Debug.LogError("Error_27180: " + _finishState);
            }
        }

        private void TryToTriggerNext()
        {
            if (mNextLoopIndex >= mAllChildList.Count)
            {
                Parent.OnChildFinish(this, CE_BT_Config.CE_BT_State.Success);
            }
            else
            {
                mAllChildList[mNextLoopIndex].OnTrigger();
            }
        }


        private int GetChildIndex(I_CE_BT_Node _child) { return 0; }
    }
}