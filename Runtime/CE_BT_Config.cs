namespace Plugins.CE_BehaviorTree.Runtime
{
    public static class CE_BT_Config
    {
        public enum CE_BT_State
        {
            None,
            Failure,
            Success,
            Running
        }

        public enum CE_BT_FinishStrategy
        {
            AbortOnFirstFailure,
            AbortOnFirstSucceed,
            FinishAll_And, //无论如何完成所有的Action.所有Action的结果做And操作(其中有一个Failure则整体认为Failure)
            FinishAll_Or, //无论如何完成所有的Action,所有的Action结果做Or操作(有一个Success则认为Success)
            FinishAll_Succeed, //全部都执行,一定返回Success
            FinishAll_Failure, //全部都执行,一定返回Failure
        }
    }
}