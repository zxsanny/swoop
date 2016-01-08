using System;
using System.ComponentModel;

namespace Swoop.Common.Extensions
{
    public static class CrossThreadExtensions
    {
        public static void InvokeEx<T>(this T component, Action<T> action) where T : ISynchronizeInvoke
        {
            if (component.InvokeRequired)
                component.Invoke(action, new object[] {component});
            else
                action(component);
        }
    }
}
