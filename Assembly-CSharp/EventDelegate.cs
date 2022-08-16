// Decompiled with JetBrains decompiler
// Type: EventDelegate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class EventDelegate
{
  [SerializeField]
  private MonoBehaviour mTarget;
  [SerializeField]
  private string mMethodName;
  [SerializeField]
  private EventDelegate.Parameter[] mParameters;
  public bool oneShot;
  [NonSerialized]
  private EventDelegate.Callback mCachedCallback;
  [NonSerialized]
  private bool mRawDelegate;
  [NonSerialized]
  private bool mCached;
  [NonSerialized]
  private MethodInfo mMethod;
  [NonSerialized]
  private ParameterInfo[] mParameterInfos;
  [NonSerialized]
  private object[] mArgs;
  private static int s_Hash = nameof (EventDelegate).GetHashCode();

  public MonoBehaviour target
  {
    get => this.mTarget;
    set
    {
      this.mTarget = value;
      this.mCachedCallback = (EventDelegate.Callback) null;
      this.mRawDelegate = false;
      this.mCached = false;
      this.mMethod = (MethodInfo) null;
      this.mParameterInfos = (ParameterInfo[]) null;
      this.mParameters = (EventDelegate.Parameter[]) null;
    }
  }

  public string methodName
  {
    get => this.mMethodName;
    set
    {
      this.mMethodName = value;
      this.mCachedCallback = (EventDelegate.Callback) null;
      this.mRawDelegate = false;
      this.mCached = false;
      this.mMethod = (MethodInfo) null;
      this.mParameterInfos = (ParameterInfo[]) null;
      this.mParameters = (EventDelegate.Parameter[]) null;
    }
  }

  public EventDelegate.Parameter[] parameters
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      return this.mParameters;
    }
  }

  public bool isValid
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      if (this.mRawDelegate && this.mCachedCallback != null)
        return true;
      return (UnityEngine.Object) this.mTarget != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.mMethodName);
    }
  }

  public bool isEnabled
  {
    get
    {
      if (!this.mCached)
        this.Cache();
      if (this.mRawDelegate && this.mCachedCallback != null)
        return true;
      if ((UnityEngine.Object) this.mTarget == (UnityEngine.Object) null)
        return false;
      MonoBehaviour mTarget = this.mTarget;
      return (UnityEngine.Object) mTarget == (UnityEngine.Object) null || mTarget.enabled;
    }
  }

  public EventDelegate()
  {
  }

  public EventDelegate(EventDelegate.Callback call) => this.Set(call);

  public EventDelegate(MonoBehaviour target, string methodName) => this.Set(target, methodName);

  private static string GetMethodName(EventDelegate.Callback callback) => callback.Method.Name;

  private static bool IsValid(EventDelegate.Callback callback) => callback != null && callback.Method != (MethodInfo) null;

  public override bool Equals(object obj)
  {
    switch (obj)
    {
      case null:
        return !this.isValid;
      case EventDelegate.Callback _:
        EventDelegate.Callback callback = obj as EventDelegate.Callback;
        if (callback.Equals((object) this.mCachedCallback))
          return true;
        return (UnityEngine.Object) this.mTarget == (UnityEngine.Object) (callback.Target as MonoBehaviour) && string.Equals(this.mMethodName, EventDelegate.GetMethodName(callback));
      case EventDelegate _:
        EventDelegate eventDelegate = obj as EventDelegate;
        return (UnityEngine.Object) this.mTarget == (UnityEngine.Object) eventDelegate.mTarget && string.Equals(this.mMethodName, eventDelegate.mMethodName);
      default:
        return false;
    }
  }

  public override int GetHashCode() => EventDelegate.s_Hash;

  private void Set(EventDelegate.Callback call)
  {
    this.Clear();
    if (call == null || !EventDelegate.IsValid(call))
      return;
    this.mTarget = call.Target as MonoBehaviour;
    if ((UnityEngine.Object) this.mTarget == (UnityEngine.Object) null)
    {
      this.mRawDelegate = true;
      this.mCachedCallback = call;
      this.mMethodName = (string) null;
    }
    else
    {
      this.mMethodName = EventDelegate.GetMethodName(call);
      this.mRawDelegate = false;
    }
  }

  public void Set(MonoBehaviour target, string methodName)
  {
    this.Clear();
    this.mTarget = target;
    this.mMethodName = methodName;
  }

  private void Cache()
  {
    this.mCached = true;
    if (this.mRawDelegate || this.mCachedCallback != null && !((UnityEngine.Object) (this.mCachedCallback.Target as MonoBehaviour) != (UnityEngine.Object) this.mTarget) && !(EventDelegate.GetMethodName(this.mCachedCallback) != this.mMethodName) || !((UnityEngine.Object) this.mTarget != (UnityEngine.Object) null) || string.IsNullOrEmpty(this.mMethodName))
      return;
    System.Type type = ((object) this.mTarget).GetType();
    this.mMethod = (MethodInfo) null;
    for (; type != (System.Type) null; type = type.BaseType)
    {
      try
      {
        this.mMethod = type.GetMethod(this.mMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (this.mMethod != (MethodInfo) null)
          break;
      }
      catch (Exception ex)
      {
      }
    }
    if (this.mMethod == (MethodInfo) null)
      Debug.LogError((object) ("Could not find method '" + this.mMethodName + "' on " + ((object) this.mTarget).GetType()?.ToString()), (UnityEngine.Object) this.mTarget);
    else if (this.mMethod.ReturnType != typeof (void))
    {
      Debug.LogError((object) (((object) this.mTarget).GetType()?.ToString() + "." + this.mMethodName + " must have a 'void' return type."), (UnityEngine.Object) this.mTarget);
    }
    else
    {
      this.mParameterInfos = this.mMethod.GetParameters();
      if (this.mParameterInfos.Length == 0)
      {
        this.mCachedCallback = (EventDelegate.Callback) Delegate.CreateDelegate(typeof (EventDelegate.Callback), (object) this.mTarget, this.mMethodName);
        this.mArgs = (object[]) null;
        this.mParameters = (EventDelegate.Parameter[]) null;
      }
      else
      {
        this.mCachedCallback = (EventDelegate.Callback) null;
        if (this.mParameters == null || this.mParameters.Length != this.mParameterInfos.Length)
        {
          this.mParameters = new EventDelegate.Parameter[this.mParameterInfos.Length];
          int index = 0;
          for (int length = this.mParameters.Length; index < length; ++index)
            this.mParameters[index] = new EventDelegate.Parameter();
        }
        int index1 = 0;
        for (int length = this.mParameters.Length; index1 < length; ++index1)
          this.mParameters[index1].expectedType = this.mParameterInfos[index1].ParameterType;
      }
    }
  }

  public bool Execute()
  {
    if (!this.mCached)
      this.Cache();
    if (this.mCachedCallback != null)
    {
      this.mCachedCallback();
      return true;
    }
    if (!(this.mMethod != (MethodInfo) null))
      return false;
    if ((this.mParameters != null ? this.mParameters.Length : 0) == 0)
    {
      this.mMethod.Invoke((object) this.mTarget, (object[]) null);
    }
    else
    {
      if (this.mArgs == null || this.mArgs.Length != this.mParameters.Length)
        this.mArgs = new object[this.mParameters.Length];
      int index1 = 0;
      for (int length = this.mParameters.Length; index1 < length; ++index1)
        this.mArgs[index1] = this.mParameters[index1].value;
      try
      {
        this.mMethod.Invoke((object) this.mTarget, this.mArgs);
      }
      catch (ArgumentException ex)
      {
        string str1 = "Error calling ";
        string str2 = (!((UnityEngine.Object) this.mTarget == (UnityEngine.Object) null) ? str1 + ((object) this.mTarget).GetType()?.ToString() + "." + this.mMethod.Name : str1 + this.mMethod.Name) + ": " + ex.Message + "\n  Expected: ";
        string str3;
        if (this.mParameterInfos.Length == 0)
        {
          str3 = str2 + "no arguments";
        }
        else
        {
          str3 = str2 + this.mParameterInfos[0]?.ToString();
          for (int index2 = 1; index2 < this.mParameterInfos.Length; ++index2)
            str3 = str3 + ", " + this.mParameterInfos[index2].ParameterType?.ToString();
        }
        string str4 = str3 + "\n  Received: ";
        string str5;
        if (this.mParameters.Length == 0)
        {
          str5 = str4 + "no arguments";
        }
        else
        {
          str5 = str4 + this.mParameters[0].type?.ToString();
          for (int index3 = 1; index3 < this.mParameters.Length; ++index3)
            str5 = str5 + ", " + this.mParameters[index3].type?.ToString();
        }
        Debug.LogError((object) (str5 + "\n"));
      }
      int index4 = 0;
      for (int length = this.mArgs.Length; index4 < length; ++index4)
      {
        if (this.mParameterInfos[index4].IsIn || this.mParameterInfos[index4].IsOut)
          this.mParameters[index4].value = this.mArgs[index4];
        this.mArgs[index4] = (object) null;
      }
    }
    return true;
  }

  public void Clear()
  {
    this.mTarget = (MonoBehaviour) null;
    this.mMethodName = (string) null;
    this.mRawDelegate = false;
    this.mCachedCallback = (EventDelegate.Callback) null;
    this.mParameters = (EventDelegate.Parameter[]) null;
    this.mCached = false;
    this.mMethod = (MethodInfo) null;
    this.mParameterInfos = (ParameterInfo[]) null;
    this.mArgs = (object[]) null;
  }

  public override string ToString()
  {
    if ((UnityEngine.Object) this.mTarget != (UnityEngine.Object) null)
    {
      string str = ((object) this.mTarget).GetType().ToString();
      int num = str.LastIndexOf('.');
      if (num > 0)
        str = str.Substring(num + 1);
      return !string.IsNullOrEmpty(this.methodName) ? str + "/" + this.methodName : str + "/[delegate]";
    }
    return !this.mRawDelegate ? (string) null : "[delegate]";
  }

  public static void Execute(List<EventDelegate> list)
  {
    if (list == null)
      return;
    int index = 0;
    while (index < list.Count)
    {
      EventDelegate eventDelegate = list[index];
      if (eventDelegate != null)
      {
        try
        {
          eventDelegate.Execute();
        }
        catch (Exception ex)
        {
          if (ex.InnerException != null)
            Debug.LogException(ex.InnerException);
          else
            Debug.LogException(ex);
        }
        if (index >= list.Count)
          break;
        if (list[index] == eventDelegate)
        {
          if (eventDelegate.oneShot)
          {
            list.RemoveAt(index);
            continue;
          }
        }
        else
          continue;
      }
      ++index;
    }
  }

  public static bool IsValid(List<EventDelegate> list)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.isValid)
          return true;
      }
    }
    return false;
  }

  public static EventDelegate Set(
    List<EventDelegate> list,
    EventDelegate.Callback callback)
  {
    if (list == null)
      return (EventDelegate) null;
    EventDelegate eventDelegate = new EventDelegate(callback);
    list.Clear();
    list.Add(eventDelegate);
    return eventDelegate;
  }

  public static void Set(List<EventDelegate> list, EventDelegate del)
  {
    if (list == null)
      return;
    list.Clear();
    list.Add(del);
  }

  public static EventDelegate Add(
    List<EventDelegate> list,
    EventDelegate.Callback callback)
  {
    return EventDelegate.Add(list, callback, false);
  }

  public static EventDelegate Add(
    List<EventDelegate> list,
    EventDelegate.Callback callback,
    bool oneShot)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) callback))
          return eventDelegate;
      }
      EventDelegate eventDelegate1 = new EventDelegate(callback);
      eventDelegate1.oneShot = oneShot;
      list.Add(eventDelegate1);
      return eventDelegate1;
    }
    Debug.LogWarning((object) "Attempting to add a callback to a list that's null");
    return (EventDelegate) null;
  }

  public static void Add(List<EventDelegate> list, EventDelegate ev) => EventDelegate.Add(list, ev, ev.oneShot);

  public static void Add(List<EventDelegate> list, EventDelegate ev, bool oneShot)
  {
    if (ev.mRawDelegate || (UnityEngine.Object) ev.target == (UnityEngine.Object) null || string.IsNullOrEmpty(ev.methodName))
      EventDelegate.Add(list, ev.mCachedCallback, oneShot);
    else if (list != null)
    {
      int index1 = 0;
      for (int count = list.Count; index1 < count; ++index1)
      {
        EventDelegate eventDelegate = list[index1];
        if (eventDelegate != null && eventDelegate.Equals((object) ev))
          return;
      }
      EventDelegate eventDelegate1 = new EventDelegate(ev.target, ev.methodName);
      eventDelegate1.oneShot = oneShot;
      if (ev.mParameters != null && ev.mParameters.Length != 0)
      {
        eventDelegate1.mParameters = new EventDelegate.Parameter[ev.mParameters.Length];
        for (int index2 = 0; index2 < ev.mParameters.Length; ++index2)
          eventDelegate1.mParameters[index2] = ev.mParameters[index2];
      }
      list.Add(eventDelegate1);
    }
    else
      Debug.LogWarning((object) "Attempting to add a callback to a list that's null");
  }

  public static bool Remove(List<EventDelegate> list, EventDelegate.Callback callback)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) callback))
        {
          list.RemoveAt(index);
          return true;
        }
      }
    }
    return false;
  }

  public static bool Remove(List<EventDelegate> list, EventDelegate ev)
  {
    if (list != null)
    {
      int index = 0;
      for (int count = list.Count; index < count; ++index)
      {
        EventDelegate eventDelegate = list[index];
        if (eventDelegate != null && eventDelegate.Equals((object) ev))
        {
          list.RemoveAt(index);
          return true;
        }
      }
    }
    return false;
  }

  [Serializable]
  public class Parameter
  {
    public UnityEngine.Object obj;
    public string field;
    [NonSerialized]
    private object mValue;
    [NonSerialized]
    public System.Type expectedType = typeof (void);
    [NonSerialized]
    public bool cached;
    [NonSerialized]
    public PropertyInfo propInfo;
    [NonSerialized]
    public FieldInfo fieldInfo;

    public Parameter()
    {
    }

    public Parameter(UnityEngine.Object obj, string field)
    {
      this.obj = obj;
      this.field = field;
    }

    public Parameter(object val) => this.mValue = val;

    public object value
    {
      get
      {
        if (this.mValue != null)
          return this.mValue;
        if (!this.cached)
        {
          this.cached = true;
          this.fieldInfo = (FieldInfo) null;
          this.propInfo = (PropertyInfo) null;
          if (this.obj != (UnityEngine.Object) null && !string.IsNullOrEmpty(this.field))
          {
            System.Type type = ((object) this.obj).GetType();
            this.propInfo = type.GetProperty(this.field);
            if (this.propInfo == (PropertyInfo) null)
              this.fieldInfo = type.GetField(this.field);
          }
        }
        if (this.propInfo != (PropertyInfo) null)
          return this.propInfo.GetValue((object) this.obj, (object[]) null);
        if (this.fieldInfo != (FieldInfo) null)
          return this.fieldInfo.GetValue((object) this.obj);
        if (this.obj != (UnityEngine.Object) null)
          return (object) this.obj;
        return this.expectedType != (System.Type) null && this.expectedType.IsValueType ? (object) null : Convert.ChangeType((object) null, this.expectedType);
      }
      set => this.mValue = value;
    }

    public System.Type type
    {
      get
      {
        if (this.mValue != null)
          return this.mValue.GetType();
        return this.obj == (UnityEngine.Object) null ? typeof (void) : ((object) this.obj).GetType();
      }
    }
  }

  public delegate void Callback();
}
