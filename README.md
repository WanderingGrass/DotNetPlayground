# .NET Playground

这个仓库包含了 .NET 平台的各种示例代码，帮助开发者更好地理解和使用 .NET。每个示例都包含详细注释和单元测试。

## 项目结构

- `src/Basic`: 基础特性示例
  - 集合操作与优化
  - LINQ 最佳实践
  - 多线程编程
  - 泛型高级用法
  - 委托与事件

  
- `src/CSharpFeatures`: C# 语言新特性示例
  - C# 12 特性展示
      
- `src/DotnetFeatures`: Dotnet新特性示例
  -.NET 9 特性展示

- `src/Advanced`: 高级特性示例
  - 内存管理与优化
  - 反射与元数据
  - 异步编程模式
  - 性能优化技巧
  
- `src/Patterns`: 设计模式实现
  - 创建型模式
  - 结构型模式
  - 行为型模式
  
- `tests`: 单元测试
  - 示例代码测试
  - 性能基准测试
  
- `samples`: 完整应用示例
  - Web API 最佳实践
  - 控制台应用程序
  - 微服务架构示例




##  委托与事件
    -  什么是委托？什么是事件？
        委托是方法的类型安全引用，可以看作是方法的指针。事件是基于委托的一种特殊封装，提供了一种发布-订阅模型。
    -  事件是如何防止外部触发的？
        事件在编译时会生成两个特殊方法（add_EventName 和 remove_EventName），并且限制了外部访问权限。
    -  什么时候使用委托，什么时候使用事件？
        当需要方法回调时使用委托；当需要实现发布-订阅模式时使用事件。
    -  委托的调用性能如何？有什么优化方式
        委托调用会有轻微的性能开销。可以使用缓存委托实例、避免频繁创建委托等方式优化。

## 🤝 贡献

欢迎提交 Pull Request 或创建 Issue！

## 📄 许可

MIT License - 查看 [LICENSE](LICENSE) 文件了解详情

## 📮 联系方式

- GitHub: [@WanderingGrass](https://github.com/WanderingGrass)
