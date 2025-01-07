using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpFeatures.CSharp_13
{
    public static class Disposer
    {
        /// <summary>
        /// - `ref struct` 是一种特殊的值类型，只能在栈上分配，不能放在堆上
        /// - `allows ref struct` 是一个泛型约束，表示该泛型参数可以接受 `ref struct` 类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="disposables"></param>
        public static void DisposeAll<T>(IEnumerable<T> disposables) where T : IDisposable, allows ref struct
        {
            foreach (T disposable in disposables)
            {
                disposable.Dispose();
            }
        }
        /// <summary>
        /// - 这是一个属性（Attribute），用于控制方法重载的解析优先级
        /// - 当有多个重载方法可用时，编译器会优先选择具有更高优先级的重载版本
        ///  数字越大，优先级越高
        ///  当你有好的性能，优选选择这个版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="disposables"></param>
        [OverloadResolutionPriority(1)]
        public static void DisposeAll<T>(params ReadOnlySpan<T> disposables) where T : IDisposable
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
        public static void DisposeAll<T>(ImmutableArray<T> disposables) where T : IDisposable
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
    }
}