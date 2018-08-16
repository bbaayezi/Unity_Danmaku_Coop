# 敌机预制件制作文档

## 更新

取消子弹组Holder的概念，使用`EnemyBulletController`脚本用于生成子弹的逻辑，另外每个子弹都挂载`BulletMotionController`用于控制运动。生成子弹通过配置文件来设置，请与`Resources`文件夹下新建`Assets/Create/Unity_Danmaku_Coop/BulletMotionCfg`资源文件来创建生成子弹逻辑，并挂载至相应的`EnemyBulletController`脚本上。

## 结构

由目前已经做好的原型来看，敌机精灵统一放至场景下的Enemy中，该游戏对象包括`Enemy Main Controller`用来控制敌机的生成，`Enemy Bullet Controller`用来统一管理敌机的子弹的运动规则，`EnemyMotionController`作为每一个挂载至敌机对象脚本的依赖脚本，用于控制敌机的运动逻辑。

敌机自身，子弹组，子弹组的holder将进行分离管理，分别对应三个预制件。

## 逻辑

|        预制件         |                功能                |   依赖    |
| :-------------------: | :--------------------------------: | :-------: |
|   敌机`enemy_[any]`   |   敌机自身具有固定的子弹生成频率   | 脚本项[1] |
| 子弹组`bullets_[any]` | 子弹组预制件仅记录子弹组的初始位置 |    无     |

[^1]: 包括运动轨迹控制脚本`EnemyMotionController`和子弹生成控制脚本`EnemyBulletSpawner`



### 敌机类型[e_type]

敌机分为四种类型，`small`, `medium`, `large`, `extralarge`，至于颜色可以从预制件的缩略图看出，在此不做区分。

### 敌机运动状态[e_motion_type]

这里的运动状态指敌机的初始运动状态，分为三种，`straight`, `bias_0`和`bias_1`。其中`straight`代表正面显示，播放正面显示动画。`bias_0`代表面向屏幕左侧侧身，入场时播放面向屏幕左侧侧身的动画。`bias_1`则反之。

### 子弹运动类型[b_motion_type]

子弹类型可能会在之后持续更新，因此做成表格：

|  类型  |   命名   |                描述                |
| :----: | :------: | :--------------------------------: |
| 发散型 | `spread` | 由一点集中生成，并向不同方向发散。 |
| 单发型 | `single` |        一次只发射单发子弹。        |

### 子弹颜色[b_color]

鉴于子弹颜色在不同背景下可能会对玩家的视觉造成影响，因此显式标注

## 命名

| 物体 |              命名规则               |
| :--: | :---------------------------------: |
| 敌机 |  `enemy_[e_type]_[e_motion_type]`   |
| 子弹 | `bullets_[b_motion_type]_[b_color]` |

