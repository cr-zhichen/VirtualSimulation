using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 事件管理
/// </summary>
public static class EventCenter
{
    static Dictionary<ENventType, Delegate> m_EventTable = new Dictionary<ENventType, Delegate>();

    static void OnListenerAdding(ENventType eventType, Delegate callBack)
    {
        if (!m_EventTable.ContainsKey(eventType))
        {
            m_EventTable.Add(eventType, null);
        }

        Delegate d = m_EventTable[eventType];
        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("尝试为事件{0}添加不同类型的委托，当前事件对应的的委托是{1}，要添加的委托类型是{2}", eventType, d.GetType(),
                callBack));
        }
    }

    static void OnListenerRemoving(ENventType eventType, Delegate callBack)
    {
        if (m_EventTable.ContainsKey(eventType))
        {
            Delegate d = m_EventTable[eventType];
            if (d == null)
            {
                throw new Exception(string.Format("移除监听错误:事件{0}没有对应的委托", eventType));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("移除监听错误:尝试为事件{0}移除不同类型的委托，当前委托类型为{1}" +
                                                  ",要移除的委托的类型为{2}", eventType, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("移除监听错误:没有事件码{0}", eventType));
        }
    }

    static void OnListenerRemoved(ENventType eventType)
    {
        if (m_EventTable[eventType] == null)
        {
            m_EventTable.Remove(eventType);
        }
    }

    /// <summary>
    /// 无参添加监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void AddListener(ENventType eventType, CallBack callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack) m_EventTable[eventType] + callBack;
    }

    /// <summary>
    /// 1参添加监听的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T>(ENventType eventType, CallBack<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T>) m_EventTable[eventType] + callBack;
    }

    /// <summary>
    /// 2参添加监听的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void AddListener<T, X>(ENventType eventType, CallBack<T, X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X>) m_EventTable[eventType] + callBack;
    }

    public static void AddListener<T, X, Y>(ENventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y>) m_EventTable[eventType] + callBack;
    }

    public static void AddListener<T, X, Y, Z>(ENventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>) m_EventTable[eventType] + callBack;
    }

    public static void AddListener<T, X, Y, Z, W>(ENventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>) m_EventTable[eventType] + callBack;
    }

    /// <summary>
    /// 移除无参监听的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener(ENventType eventType, CallBack callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// 移除1参监听的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T>(ENventType eventType, CallBack<T> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T>) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// 移除2参监听的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <param name="eventType"></param>
    /// <param name="callBack"></param>
    public static void RemoveListener<T, X>(ENventType eventType, CallBack<T, X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X>) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, X, Y>(ENventType eventType, CallBack<T, X, Y> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y>) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, X, Y, Z>(ENventType eventType, CallBack<T, X, Y, Z> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z>) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    public static void RemoveListener<T, X, Y, Z, W>(ENventType eventType, CallBack<T, X, Y, Z, W> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_EventTable[eventType] = (CallBack<T, X, Y, Z, W>) m_EventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// 广播无参方法
    /// </summary>
    /// <param name="eventType"></param>
    public static void Broadcast(ENventType eventType)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }

    /// <summary>
    /// 广播1参方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg"></param>
    public static void Broadcast<T>(ENventType eventType, T arg)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }

    /// <summary>
    /// 广播2参方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    public static void Broadcast<T, X>(ENventType eventType, T arg1, X arg2)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X> callBack = d as CallBack<T, X>;
            if (callBack != null)
            {
                callBack(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }

    public static void Broadcast<T, X, Y>(ENventType eventType, T arg1, X arg2, Y arg3)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y> callBack = d as CallBack<T, X, Y>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }

    public static void Broadcast<T, X, Y, Z>(ENventType eventType, T arg1, X arg2, Y arg3, Z arg4)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z> callBack = d as CallBack<T, X, Y, Z>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }

    public static void Broadcast<T, X, Y, Z, W>(ENventType eventType, T arg1, X arg2, Y arg3, Z arg4, W arg5)
    {
        Delegate d;
        if (m_EventTable.TryGetValue(eventType, out d))
        {
            CallBack<T, X, Y, Z, W> callBack = d as CallBack<T, X, Y, Z, W>;
            if (callBack != null)
            {
                callBack(arg1, arg2, arg3, arg4, arg5);
            }
            else
            {
                throw new Exception(string.Format("广播事件错误:事件{0}对应的委托具有不同类型", eventType));
            }
        }
    }
}
