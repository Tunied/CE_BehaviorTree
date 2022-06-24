# CE_BehaviorTree
BehaviorTree implement with pure C# ★ Event Driven &amp; Observer Abort

**暂时搁置,目前需要先带入已有项目再沉淀一下.**

## The reason for wrote my own BT system

### 现有商业插件的问题

Unity现有两款比较有名的插件

[Behavior Designer - Behavior Trees for Everyone](https://assetstore.unity.com/packages/tools/visual-scripting/behavior-designer-behavior-trees-for-everyone-15277)

[Node Canvas](https://assetstore.unity.com/packages/tools/visual-scripting/nodecanvas-14914#publisher)

有以下几点我觉得不太适合我的

#### 不方便重构代码

Behavior Designer 这块做的是最差的. 只要相应的CustomNode创建后 完全无法重构,即使换个路径就会导致之前的BT文件直接报红.
并且你还完全无法知道到原来的Node是什么.


Node Canvas 有自制一个工具方便重构,并且还会提示你Missing的Node原本是什么. 这点做的就比较好了. 虽然重构费劲. 但是至少是可以.


并且Behavior Designer在这块埋下了一个非常大的隐患,尤其是多人合作的开发周期比较长的商业游戏. 很难说谁做了点什么操作导致之前文件损坏.代码回滚起来会异常麻烦.

所以 如果是大型项目 个人完全建议优先选择Node Canvas


#### 不方便混淆

Behavior Designer应该是无可能性,Node Canvas有单独生成AOT文件.理论可行 但是需要后期做大量辅助工具. 过于复杂了.


#### 不满足业务需求

##### 需求1

两款插件都有Abort机制,但是都没有Build-In支持CanNotAbort State.

比如一个节点需要控制Actor节点释放Skill去Attack. 在Skill的前摇阶段. 此时前置节点需要Trigger Abort. 比如中了一个Fear的Buff需要逃跑. 预期达到的效果是Skill前摇结束后
转入Fear的Logic.

这块简单的处理是BB中加入一个IsCanNotAbort的变量,然后每个可以Abort的Condition检测时候都要带着这个参数去检测.

- 这样BT的前置判断节点都需要 + Sequencer
- 并且这样操作以后无法处理 Skill执行完毕后仍旧触发Fear的Logic(如果Fear的Logic是One Time的话).

这个问题第一个会导致BT的设计比较冗余,第二个问题可以从设计上去尽量规避.

##### 需求2

第二个需求是 对某个SubTree的 Switch In/Out 有不同的判断逻辑.

比如Actor发现目标后开始向目标发起追击,在追击途中可以会被障碍物卡住. 在设计DuringStuckAttack时候 期望的进入条件是

- 当前Actor在N秒内移动距离低于某个值
- 周围有可以被攻击的障碍物
- 距上次进入当前SubLogic的时间 > 某个值

这个Logic的退出条件是

- 在当前SubLogic已经持续了N秒
- 周围没有可被攻击的障碍物


这种嵌套的SubTreeLogic 似乎使用现有的BT设计方案 似乎可行, 不过会导致需要大量的冗余节点.


#### Design For Codeless

两款插件从设计里面上都是为了Codeless设计,就我个人认为BT应该更多应用于高层级的AI决策上,而对于LowLevel的Unity组件操作本就不应该放在Node里面.当然是针对有一定规模的项目来说.

所以两款插件各种花了呼哨的Node搞了一堆.其实对于正经项目开发来说意义不是很大.




