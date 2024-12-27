namespace Basic;

/// <summary>
/// 基础概念答案：
/// 委托是一种引用类型，本质是一个类，用于存储方法的引用
/// 事件是基于委托的一种特殊封装，提供了一种发布-订阅模式的实现
/// 
///   - 委托可以直接赋值，事件只能使用 += 和 -=
///   - 委托可以在类外部触发，事件只能在声明类内部触发
///   - 委托可以获取调用列表，事件不能直接访问调用列表
///   
/// </summary>
public class DelegateAndEventExmpole
{

}
public delegate void MessageHandler(string message);

public class Publisher
{
    //public MessageHandler OnMessageReceived;  // 这里使用委托而不是事件可能带来什么问题？
    //封装性破坏，外部可以直接清空
    //Publisher publisher = new Publisher();
    //publisher.OnMessageReceived = null; 
    public event MessageHandler OnMessageReceived;

    public void SendMessage(string message)
    {
        OnMessageReceived?.Invoke(message);
    }
}


/// 事件在底层是通过以下方式实现的：
/// 编译器会为事件生成一个私有的委托字段
/// 生成 add 和 remove 访问器方法
/// 这些访问器使用 Interlocked.CompareExchange 来确保线程安全
public class Publisher1
{
    // 编译器生成的私有委托字段
    private MessageHandler _onMessageReceived;

    // 事件的 add 访问器
    public event MessageHandler OnMessageReceived
    {
        add
        {
            MessageHandler handler2;
            MessageHandler handler = this._onMessageReceived;
            do
            {
                handler2 = handler;
                handler = Interlocked.CompareExchange(
                    ref this._onMessageReceived,
                    (MessageHandler)Delegate.Combine(handler2, value),
                    handler2);
            }
            while (handler != handler2);
        }
        remove
        {
            MessageHandler handler2;
            MessageHandler handler = this._onMessageReceived;
            do
            {
                handler2 = handler;
                handler = Interlocked.CompareExchange(
                    ref this._onMessageReceived,
                    (MessageHandler)Delegate.Remove(handler2, value),
                    handler2);
            }
            while (handler != handler2);
        }
    }
}

