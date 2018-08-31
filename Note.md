# 游戏编程模式笔记

## 命令模式

命令就是面向对象化的回调(Commands are an object-oriented replacement for callbacks)

例：

本笔记的示例会结合相关设计模式与Unity，也许不是最佳的实践方法，仅供参考

处理用户输入和行为的映射时，我们最先想到的实现可能如下所示：

```c#
class InputHandler
{
    void HandleInput()
    {
        if (isPressed(BUTTON_X)) Jump();
        else if (isPressed(BUTTON_Y)) FireGun();
        else if (isPressed(BUTTON_A)) SwapWeapon();
        else if (isPressed(BUTTON_B)) LaunchIneffectively();
    }
}
```

以上代码将在游戏的每一帧循环当中被调用并且是有效的，但是假设我们需要添加用户可自定义配置的功能支持，以上“特定按键执行特定函数”的方式便显现出缺陷。我们需要把对方法的直接调用如`Jump()`和`FireGun()`转变为我们可以替换(swap out)的东西，所以我们需要一个对象来代表游戏动作。于是我们定义一个基类用来代表一个客出发的游戏命令：

```c#
public class Command
{
    public virtual void Execute() {};
}
```

之后，再为每个不同的游戏动作创建一个子类

```c#
class JumpCommand : Command
{
	public override void Execute() { Jump(); };
}

class FireCommand : Command
{
	public override void Execute() { Fire(); };
}

// ...
```

接着我们在输入处理中为每个按钮储存一个指向它的指针

```c#
class InputHandler
{
    private Command _BUTTON_X;
    private Command _BUTTON_Y;
    private Command _BUTTON_A;
    private Command _BUTTON_B;
    
    // 绑定这些命令
    _BUTTON_X = new JumpCommand();
    //...
    
    // 之后我们的输入处理将通过这些对象引用进行代理
    
    void HandleInput()
    {
        if (isPressed(BUTTON_X)) _BUTTON_X.Execute();
        else if (isPressed(BUTTON_Y)) _BUTTON_Y.Execute();
        else if (isPressed(BUTTON_A)) _BUTTON_A.Execute();
        else if (isPressed(BUTTON_B)) _BUTTON_B.Execute();
    }
}
```

在Unity中，我们需要先获取`GameObject`所绑定的`Script Component`并且执行相应的操作，因此我们改写`Command`:

```c#
public abstract class Command 
{
	public virtual void Execute<T>(GameObject gameObject) where T : ICommandable {}
}
```

并添加接口`ICommandable`:

```c#
public interface ICommandable
{
	void Shoot();
	void Move(Vector2 Movement);
}
```

这样，我们的`InputHandler`子类就可以写成：

```c#
public class ShootCommand : Command
{
	public override void Execute<T>(GameObject gameObject)
	{
		gameObject.GetComponent<T>().Shoot();
	}
}
```

同时我们改写`IsPressed`方法使之能够输出相对应Axis的值：

```c#
bool IsPressed(string axisName, out float axisValue)
{
	float input = Input.GetAxis(axisName);
	if (input > 0.01f || input < -0.01f)
	{
		axisValue = input;
		return true;
	}
	else
	{
		axisValue = 0;
		return false;
	}
}
```

