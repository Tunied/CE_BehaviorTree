namespace Plugins.CE_BehaviorTree.Runtime
{
    public interface I_CE_BT_Condition
    {
        CE_BT_ConditionExecutor Holder { set; }

        /// <summary>
        /// 在Executor返回结果之前调用该函数,并且传入本次Executor返回的结果
        /// 使当前Condition有机会在返回时候做些操作
        /// - ex: BT_Condition_IsHaveObstacleNeraBy
        ///       当Holder返回时候调用OnExecutorFinish,在BB中设置Obstacle. 后续的Action在执行时候就能确保目标
        /// 
        /// </summary>
        /// <param name="_finishState"></param>
        void OnExecutorFinish(CE_BT_Config.CE_BT_State _finishState);
    }
}