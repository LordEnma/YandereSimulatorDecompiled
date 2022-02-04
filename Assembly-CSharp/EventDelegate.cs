using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Token: 0x02000072 RID: 114
[Serializable]
public class EventDelegate
{
	// Token: 0x17000059 RID: 89
	// (get) Token: 0x06000334 RID: 820 RVA: 0x00020BB9 File Offset: 0x0001EDB9
	// (set) Token: 0x06000335 RID: 821 RVA: 0x00020BC1 File Offset: 0x0001EDC1
	public MonoBehaviour target
	{
		get
		{
			return this.mTarget;
		}
		set
		{
			this.mTarget = value;
			this.mCachedCallback = null;
			this.mRawDelegate = false;
			this.mCached = false;
			this.mMethod = null;
			this.mParameterInfos = null;
			this.mParameters = null;
		}
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x06000336 RID: 822 RVA: 0x00020BF4 File Offset: 0x0001EDF4
	// (set) Token: 0x06000337 RID: 823 RVA: 0x00020BFC File Offset: 0x0001EDFC
	public string methodName
	{
		get
		{
			return this.mMethodName;
		}
		set
		{
			this.mMethodName = value;
			this.mCachedCallback = null;
			this.mRawDelegate = false;
			this.mCached = false;
			this.mMethod = null;
			this.mParameterInfos = null;
			this.mParameters = null;
		}
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x06000338 RID: 824 RVA: 0x00020C2F File Offset: 0x0001EE2F
	public EventDelegate.Parameter[] parameters
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			return this.mParameters;
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x06000339 RID: 825 RVA: 0x00020C45 File Offset: 0x0001EE45
	public bool isValid
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			return (this.mRawDelegate && this.mCachedCallback != null) || (this.mTarget != null && !string.IsNullOrEmpty(this.mMethodName));
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x0600033A RID: 826 RVA: 0x00020C88 File Offset: 0x0001EE88
	public bool isEnabled
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mRawDelegate && this.mCachedCallback != null)
			{
				return true;
			}
			if (this.mTarget == null)
			{
				return false;
			}
			MonoBehaviour monoBehaviour = this.mTarget;
			return monoBehaviour == null || monoBehaviour.enabled;
		}
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00020CDD File Offset: 0x0001EEDD
	public EventDelegate()
	{
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00020CE5 File Offset: 0x0001EEE5
	public EventDelegate(EventDelegate.Callback call)
	{
		this.Set(call);
	}

	// Token: 0x0600033D RID: 829 RVA: 0x00020CF4 File Offset: 0x0001EEF4
	public EventDelegate(MonoBehaviour target, string methodName)
	{
		this.Set(target, methodName);
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00020D04 File Offset: 0x0001EF04
	private static string GetMethodName(EventDelegate.Callback callback)
	{
		return callback.Method.Name;
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00020D11 File Offset: 0x0001EF11
	private static bool IsValid(EventDelegate.Callback callback)
	{
		return callback != null && callback.Method != null;
	}

	// Token: 0x06000340 RID: 832 RVA: 0x00020D24 File Offset: 0x0001EF24
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return !this.isValid;
		}
		if (obj is EventDelegate.Callback)
		{
			EventDelegate.Callback callback = obj as EventDelegate.Callback;
			if (callback.Equals(this.mCachedCallback))
			{
				return true;
			}
			MonoBehaviour y = callback.Target as MonoBehaviour;
			return this.mTarget == y && string.Equals(this.mMethodName, EventDelegate.GetMethodName(callback));
		}
		else
		{
			if (obj is EventDelegate)
			{
				EventDelegate eventDelegate = obj as EventDelegate;
				return this.mTarget == eventDelegate.mTarget && string.Equals(this.mMethodName, eventDelegate.mMethodName);
			}
			return false;
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00020DC2 File Offset: 0x0001EFC2
	public override int GetHashCode()
	{
		return EventDelegate.s_Hash;
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00020DCC File Offset: 0x0001EFCC
	private void Set(EventDelegate.Callback call)
	{
		this.Clear();
		if (call != null && EventDelegate.IsValid(call))
		{
			this.mTarget = (call.Target as MonoBehaviour);
			if (this.mTarget == null)
			{
				this.mRawDelegate = true;
				this.mCachedCallback = call;
				this.mMethodName = null;
				return;
			}
			this.mMethodName = EventDelegate.GetMethodName(call);
			this.mRawDelegate = false;
		}
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00020E32 File Offset: 0x0001F032
	public void Set(MonoBehaviour target, string methodName)
	{
		this.Clear();
		this.mTarget = target;
		this.mMethodName = methodName;
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00020E48 File Offset: 0x0001F048
	private void Cache()
	{
		this.mCached = true;
		if (this.mRawDelegate)
		{
			return;
		}
		if ((this.mCachedCallback == null || this.mCachedCallback.Target as MonoBehaviour != this.mTarget || EventDelegate.GetMethodName(this.mCachedCallback) != this.mMethodName) && this.mTarget != null && !string.IsNullOrEmpty(this.mMethodName))
		{
			Type type = this.mTarget.GetType();
			this.mMethod = null;
			while (type != null)
			{
				try
				{
					this.mMethod = type.GetMethod(this.mMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (this.mMethod != null)
					{
						break;
					}
				}
				catch (Exception)
				{
				}
				type = type.BaseType;
			}
			if (this.mMethod == null)
			{
				string str = "Could not find method '";
				string str2 = this.mMethodName;
				string str3 = "' on ";
				Type type2 = this.mTarget.GetType();
				Debug.LogError(str + str2 + str3 + ((type2 != null) ? type2.ToString() : null), this.mTarget);
				return;
			}
			if (this.mMethod.ReturnType != typeof(void))
			{
				Type type3 = this.mTarget.GetType();
				Debug.LogError(((type3 != null) ? type3.ToString() : null) + "." + this.mMethodName + " must have a 'void' return type.", this.mTarget);
				return;
			}
			this.mParameterInfos = this.mMethod.GetParameters();
			if (this.mParameterInfos.Length == 0)
			{
				this.mCachedCallback = (EventDelegate.Callback)Delegate.CreateDelegate(typeof(EventDelegate.Callback), this.mTarget, this.mMethodName);
				this.mArgs = null;
				this.mParameters = null;
				return;
			}
			this.mCachedCallback = null;
			if (this.mParameters == null || this.mParameters.Length != this.mParameterInfos.Length)
			{
				this.mParameters = new EventDelegate.Parameter[this.mParameterInfos.Length];
				int i = 0;
				int num = this.mParameters.Length;
				while (i < num)
				{
					this.mParameters[i] = new EventDelegate.Parameter();
					i++;
				}
			}
			int j = 0;
			int num2 = this.mParameters.Length;
			while (j < num2)
			{
				this.mParameters[j].expectedType = this.mParameterInfos[j].ParameterType;
				j++;
			}
		}
	}

	// Token: 0x06000345 RID: 837 RVA: 0x00021098 File Offset: 0x0001F298
	public bool Execute()
	{
		if (!this.mCached)
		{
			this.Cache();
		}
		if (this.mCachedCallback != null)
		{
			this.mCachedCallback();
			return true;
		}
		if (this.mMethod != null)
		{
			if (this.mParameters == null || this.mParameters.Length == 0)
			{
				this.mMethod.Invoke(this.mTarget, null);
			}
			else
			{
				if (this.mArgs == null || this.mArgs.Length != this.mParameters.Length)
				{
					this.mArgs = new object[this.mParameters.Length];
				}
				int i = 0;
				int num = this.mParameters.Length;
				while (i < num)
				{
					this.mArgs[i] = this.mParameters[i].value;
					i++;
				}
				try
				{
					this.mMethod.Invoke(this.mTarget, this.mArgs);
				}
				catch (ArgumentException ex)
				{
					string text = "Error calling ";
					if (this.mTarget == null)
					{
						text += this.mMethod.Name;
					}
					else
					{
						string str = text;
						Type type = this.mTarget.GetType();
						text = str + ((type != null) ? type.ToString() : null) + "." + this.mMethod.Name;
					}
					text = text + ": " + ex.Message;
					text += "\n  Expected: ";
					if (this.mParameterInfos.Length == 0)
					{
						text += "no arguments";
					}
					else
					{
						string str2 = text;
						ParameterInfo parameterInfo = this.mParameterInfos[0];
						text = str2 + ((parameterInfo != null) ? parameterInfo.ToString() : null);
						for (int j = 1; j < this.mParameterInfos.Length; j++)
						{
							string str3 = text;
							string str4 = ", ";
							Type parameterType = this.mParameterInfos[j].ParameterType;
							text = str3 + str4 + ((parameterType != null) ? parameterType.ToString() : null);
						}
					}
					text += "\n  Received: ";
					if (this.mParameters.Length == 0)
					{
						text += "no arguments";
					}
					else
					{
						string str5 = text;
						Type type2 = this.mParameters[0].type;
						text = str5 + ((type2 != null) ? type2.ToString() : null);
						for (int k = 1; k < this.mParameters.Length; k++)
						{
							string str6 = text;
							string str7 = ", ";
							Type type3 = this.mParameters[k].type;
							text = str6 + str7 + ((type3 != null) ? type3.ToString() : null);
						}
					}
					text += "\n";
					Debug.LogError(text);
				}
				int l = 0;
				int num2 = this.mArgs.Length;
				while (l < num2)
				{
					if (this.mParameterInfos[l].IsIn || this.mParameterInfos[l].IsOut)
					{
						this.mParameters[l].value = this.mArgs[l];
					}
					this.mArgs[l] = null;
					l++;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00021370 File Offset: 0x0001F570
	public void Clear()
	{
		this.mTarget = null;
		this.mMethodName = null;
		this.mRawDelegate = false;
		this.mCachedCallback = null;
		this.mParameters = null;
		this.mCached = false;
		this.mMethod = null;
		this.mParameterInfos = null;
		this.mArgs = null;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x000213BC File Offset: 0x0001F5BC
	public override string ToString()
	{
		if (this.mTarget != null)
		{
			string text = this.mTarget.GetType().ToString();
			int num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			if (!string.IsNullOrEmpty(this.methodName))
			{
				return text + "/" + this.methodName;
			}
			return text + "/[delegate]";
		}
		else
		{
			if (!this.mRawDelegate)
			{
				return null;
			}
			return "[delegate]";
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0002143C File Offset: 0x0001F63C
	public static void Execute(List<EventDelegate> list)
	{
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null)
				{
					try
					{
						eventDelegate.Execute();
					}
					catch (Exception ex)
					{
						if (ex.InnerException != null)
						{
							Debug.LogException(ex.InnerException);
						}
						else
						{
							Debug.LogException(ex);
						}
					}
					if (i >= list.Count)
					{
						break;
					}
					if (list[i] != eventDelegate)
					{
						continue;
					}
					if (eventDelegate.oneShot)
					{
						list.RemoveAt(i);
						continue;
					}
				}
			}
		}
	}

	// Token: 0x06000349 RID: 841 RVA: 0x000214C4 File Offset: 0x0001F6C4
	public static bool IsValid(List<EventDelegate> list)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.isValid)
				{
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00021500 File Offset: 0x0001F700
	public static EventDelegate Set(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		if (list != null)
		{
			EventDelegate eventDelegate = new EventDelegate(callback);
			list.Clear();
			list.Add(eventDelegate);
			return eventDelegate;
		}
		return null;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00021527 File Offset: 0x0001F727
	public static void Set(List<EventDelegate> list, EventDelegate del)
	{
		if (list != null)
		{
			list.Clear();
			list.Add(del);
		}
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00021539 File Offset: 0x0001F739
	public static EventDelegate Add(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		return EventDelegate.Add(list, callback, false);
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00021544 File Offset: 0x0001F744
	public static EventDelegate Add(List<EventDelegate> list, EventDelegate.Callback callback, bool oneShot)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(callback))
				{
					return eventDelegate;
				}
				i++;
			}
			EventDelegate eventDelegate2 = new EventDelegate(callback);
			eventDelegate2.oneShot = oneShot;
			list.Add(eventDelegate2);
			return eventDelegate2;
		}
		Debug.LogWarning("Attempting to add a callback to a list that's null");
		return null;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0002159F File Offset: 0x0001F79F
	public static void Add(List<EventDelegate> list, EventDelegate ev)
	{
		EventDelegate.Add(list, ev, ev.oneShot);
	}

	// Token: 0x0600034F RID: 847 RVA: 0x000215B0 File Offset: 0x0001F7B0
	public static void Add(List<EventDelegate> list, EventDelegate ev, bool oneShot)
	{
		if (ev.mRawDelegate || ev.target == null || string.IsNullOrEmpty(ev.methodName))
		{
			EventDelegate.Add(list, ev.mCachedCallback, oneShot);
			return;
		}
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(ev))
				{
					return;
				}
				i++;
			}
			EventDelegate eventDelegate2 = new EventDelegate(ev.target, ev.methodName);
			eventDelegate2.oneShot = oneShot;
			if (ev.mParameters != null && ev.mParameters.Length != 0)
			{
				eventDelegate2.mParameters = new EventDelegate.Parameter[ev.mParameters.Length];
				for (int j = 0; j < ev.mParameters.Length; j++)
				{
					eventDelegate2.mParameters[j] = ev.mParameters[j];
				}
			}
			list.Add(eventDelegate2);
			return;
		}
		Debug.LogWarning("Attempting to add a callback to a list that's null");
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00021698 File Offset: 0x0001F898
	public static bool Remove(List<EventDelegate> list, EventDelegate.Callback callback)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(callback))
				{
					list.RemoveAt(i);
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x06000351 RID: 849 RVA: 0x000216DC File Offset: 0x0001F8DC
	public static bool Remove(List<EventDelegate> list, EventDelegate ev)
	{
		if (list != null)
		{
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				EventDelegate eventDelegate = list[i];
				if (eventDelegate != null && eventDelegate.Equals(ev))
				{
					list.RemoveAt(i);
					return true;
				}
				i++;
			}
		}
		return false;
	}

	// Token: 0x0400049F RID: 1183
	[SerializeField]
	private MonoBehaviour mTarget;

	// Token: 0x040004A0 RID: 1184
	[SerializeField]
	private string mMethodName;

	// Token: 0x040004A1 RID: 1185
	[SerializeField]
	private EventDelegate.Parameter[] mParameters;

	// Token: 0x040004A2 RID: 1186
	public bool oneShot;

	// Token: 0x040004A3 RID: 1187
	[NonSerialized]
	private EventDelegate.Callback mCachedCallback;

	// Token: 0x040004A4 RID: 1188
	[NonSerialized]
	private bool mRawDelegate;

	// Token: 0x040004A5 RID: 1189
	[NonSerialized]
	private bool mCached;

	// Token: 0x040004A6 RID: 1190
	[NonSerialized]
	private MethodInfo mMethod;

	// Token: 0x040004A7 RID: 1191
	[NonSerialized]
	private ParameterInfo[] mParameterInfos;

	// Token: 0x040004A8 RID: 1192
	[NonSerialized]
	private object[] mArgs;

	// Token: 0x040004A9 RID: 1193
	private static int s_Hash = "EventDelegate".GetHashCode();

	// Token: 0x020005E3 RID: 1507
	[Serializable]
	public class Parameter
	{
		// Token: 0x0600252A RID: 9514 RVA: 0x001FC23E File Offset: 0x001FA43E
		public Parameter()
		{
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x001FC256 File Offset: 0x001FA456
		public Parameter(UnityEngine.Object obj, string field)
		{
			this.obj = obj;
			this.field = field;
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x001FC27C File Offset: 0x001FA47C
		public Parameter(object val)
		{
			this.mValue = val;
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x0600252D RID: 9517 RVA: 0x001FC29C File Offset: 0x001FA49C
		// (set) Token: 0x0600252E RID: 9518 RVA: 0x001FC3AD File Offset: 0x001FA5AD
		public object value
		{
			get
			{
				if (this.mValue != null)
				{
					return this.mValue;
				}
				if (!this.cached)
				{
					this.cached = true;
					this.fieldInfo = null;
					this.propInfo = null;
					if (this.obj != null && !string.IsNullOrEmpty(this.field))
					{
						Type type = this.obj.GetType();
						this.propInfo = type.GetProperty(this.field);
						if (this.propInfo == null)
						{
							this.fieldInfo = type.GetField(this.field);
						}
					}
				}
				if (this.propInfo != null)
				{
					return this.propInfo.GetValue(this.obj, null);
				}
				if (this.fieldInfo != null)
				{
					return this.fieldInfo.GetValue(this.obj);
				}
				if (this.obj != null)
				{
					return this.obj;
				}
				if (this.expectedType != null && this.expectedType.IsValueType)
				{
					return null;
				}
				return Convert.ChangeType(null, this.expectedType);
			}
			set
			{
				this.mValue = value;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x0600252F RID: 9519 RVA: 0x001FC3B6 File Offset: 0x001FA5B6
		public Type type
		{
			get
			{
				if (this.mValue != null)
				{
					return this.mValue.GetType();
				}
				if (this.obj == null)
				{
					return typeof(void);
				}
				return this.obj.GetType();
			}
		}

		// Token: 0x04004D71 RID: 19825
		public UnityEngine.Object obj;

		// Token: 0x04004D72 RID: 19826
		public string field;

		// Token: 0x04004D73 RID: 19827
		[NonSerialized]
		private object mValue;

		// Token: 0x04004D74 RID: 19828
		[NonSerialized]
		public Type expectedType = typeof(void);

		// Token: 0x04004D75 RID: 19829
		[NonSerialized]
		public bool cached;

		// Token: 0x04004D76 RID: 19830
		[NonSerialized]
		public PropertyInfo propInfo;

		// Token: 0x04004D77 RID: 19831
		[NonSerialized]
		public FieldInfo fieldInfo;
	}

	// Token: 0x020005E4 RID: 1508
	// (Invoke) Token: 0x06002531 RID: 9521
	public delegate void Callback();
}
