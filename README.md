# Unity_Danmaku

## Branch: bbaayezi

Hello, 这里是我（bbaayezi）的分支。

## 正在做...

按照我个人的思路去开发自机功能以及自机子弹发射功能。

------

## 当前版本（Tag）

v0.0.1

### 最新状态

- [x] 制作人物动画(默认,左移,右移)

- [ ] 制作人物预制件

- [x] 将动画绑定至人物控制脚本,并将脚本绑定至人物

- [ ] 实现自机大玉的变换动画

- [ ] 开发敌机预制体原型，确立制作规范

- [ ] 自机弹幕升级功能

- 删除抽象类`Player`: 由于玩家实体作为预制件，在场景一开始便出生在屏幕下方。与Player相关的属性集成到`PlayerControl`控制逻辑当中。

- 删除接口`IBulletControl`: 本接口主要实现子弹的Shoot以及Clear功能，~~然而实际操作中发现由单独的子弹控制器来控制子弹运动有一定的困难，因此相关的逻辑集成至`BulletSpawner`类当中。~~

- ~~子弹离开屏幕的检测采用了为屏幕上边界创建直线碰撞体的方法。~~

- 屏幕边界碰撞检测改为使用`Camera,ViewPortToScreenPoint()`方法，使用坐标进行判定，避免额外的碰撞机碰撞检测消耗。

- 对于敌机的生成，使用统一的总控制器`EnemyMainController`，(在当前进行的项目中与`Debugger`中生成敌机的逻辑相同)。而敌机本身具有`SpawnBullet()`方法用于生成子弹预制体，子弹预制体的行动规则由`EnemyBulletSpawner`统一控制。

- 创建`EnemySpawnPoints`用于定位敌机生成的世界坐标。

- 创建`Bullets`统一管理子弹，在其之下分有单个子弹以及子弹群的holder，格式为`bullets_[color]_[type]_group_holder`，`bullet_[color]_[type]_single_holder`。以`bullets_yellow_spread_group_holder`为例，其子元素包含五个不同rotation的子弹，通过子弹控制器`EnemyBulletSpawner`中每帧进行的`foreach`方法遍历此holder中所有的子弹并为其设置运动机制（`Transform.Translate`）。注意为敌机绑定子弹时，需要指定子弹的holder以及如果子弹类型为spread的话，需要手动绑定**每一个不同rotation状态的子弹**，只有这样才能正确的在holder之下动态添加子弹组，并确保`EnemyBulletSpawner`正确遍历holder之下的子弹并为其添加运动机制。

  





## 接口文档

接口将在制作的预制件原型被采用之后进行更新，用来形成之后开发预制件的规范。

首先是对于控制自机的接口，

```c#
interface IPlayerControl
```

这个接口定义了自机的控制方法

| **方法名及返回值**        | **注释**             |
| ------------------------- | -------------------- |
| `void Move()`             | 上下左右斜的控制     |
| `bool UseBomb()`          | 控制自机使用B        |
| `void SwitchToLowSpeed()` | 控制自机进入低速模式 |

[^注]: 不代表最终版本

```c#
interface ISpawnable
```

本接口为所有的子弹生成控制器限定行为，以后会逐渐完善

| **方法名及返回值**   | **注释** |
| -------------------- | -------- |
| `void SpawnBullet()` | 生成子弹 |



## 具体任务列表

- [ ] 游戏整体开发架构确立
- [ ] 自机功能开发的文档和标准确立
- [ ] 自机基础功能接口开发，包括移动，射击，放B，低速模式等
- [x] 自机子弹发射功能接口开发

## 其他

这些一开始都是自己从零开始想的，可能逻辑不那么清晰，之后应该会先去查找一些现成的架构设计与接口设计，找到更好的设计之后会及时替换（毕竟自己从头开始设计是真的难）