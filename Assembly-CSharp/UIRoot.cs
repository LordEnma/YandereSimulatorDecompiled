using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A8 RID: 168
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Root")]
public class UIRoot : MonoBehaviour
{
	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06000841 RID: 2113 RVA: 0x00044F51 File Offset: 0x00043151
	public UIRoot.Constraint constraint
	{
		get
		{
			if (this.fitWidth)
			{
				if (this.fitHeight)
				{
					return UIRoot.Constraint.Fit;
				}
				return UIRoot.Constraint.FitWidth;
			}
			else
			{
				if (this.fitHeight)
				{
					return UIRoot.Constraint.FitHeight;
				}
				return UIRoot.Constraint.Fill;
			}
		}
	}

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06000842 RID: 2114 RVA: 0x00044F74 File Offset: 0x00043174
	public UIRoot.Scaling activeScaling
	{
		get
		{
			UIRoot.Scaling scaling = this.scalingStyle;
			if (scaling == UIRoot.Scaling.ConstrainedOnMobiles)
			{
				return UIRoot.Scaling.Flexible;
			}
			return scaling;
		}
	}

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x06000843 RID: 2115 RVA: 0x00044F90 File Offset: 0x00043190
	public int activeHeight
	{
		get
		{
			if (this.activeScaling == UIRoot.Scaling.Flexible)
			{
				Vector2 screenSize = NGUITools.screenSize;
				float num = screenSize.x / screenSize.y;
				if (screenSize.y < (float)this.minimumHeight)
				{
					screenSize.y = (float)this.minimumHeight;
					screenSize.x = screenSize.y * num;
				}
				else if (screenSize.y > (float)this.maximumHeight)
				{
					screenSize.y = (float)this.maximumHeight;
					screenSize.x = screenSize.y * num;
				}
				int num2 = Mathf.RoundToInt((this.shrinkPortraitUI && screenSize.y > screenSize.x) ? (screenSize.y / num) : screenSize.y);
				if (!this.adjustByDPI)
				{
					return num2;
				}
				return NGUIMath.AdjustByDPI((float)num2);
			}
			else
			{
				UIRoot.Constraint constraint = this.constraint;
				if (constraint == UIRoot.Constraint.FitHeight)
				{
					return this.manualHeight;
				}
				Vector2 screenSize2 = NGUITools.screenSize;
				float num3 = screenSize2.x / screenSize2.y;
				float num4 = (float)this.manualWidth / (float)this.manualHeight;
				switch (constraint)
				{
				case UIRoot.Constraint.Fit:
					if (num4 <= num3)
					{
						return this.manualHeight;
					}
					return Mathf.RoundToInt((float)this.manualWidth / num3);
				case UIRoot.Constraint.Fill:
					if (num4 >= num3)
					{
						return this.manualHeight;
					}
					return Mathf.RoundToInt((float)this.manualWidth / num3);
				case UIRoot.Constraint.FitWidth:
					return Mathf.RoundToInt((float)this.manualWidth / num3);
				default:
					return this.manualHeight;
				}
			}
		}
	}

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06000844 RID: 2116 RVA: 0x000450F4 File Offset: 0x000432F4
	public float pixelSizeAdjustment
	{
		get
		{
			int num = Mathf.RoundToInt(NGUITools.screenSize.y);
			if (num != -1)
			{
				return this.GetPixelSizeAdjustment(num);
			}
			return 1f;
		}
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x00045124 File Offset: 0x00043324
	public static float GetPixelSizeAdjustment(GameObject go)
	{
		UIRoot uiroot = NGUITools.FindInParents<UIRoot>(go);
		if (!(uiroot != null))
		{
			return 1f;
		}
		return uiroot.pixelSizeAdjustment;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00045150 File Offset: 0x00043350
	public float GetPixelSizeAdjustment(int height)
	{
		height = Mathf.Max(2, height);
		if (this.activeScaling == UIRoot.Scaling.Constrained)
		{
			return (float)this.activeHeight / (float)height;
		}
		if (height < this.minimumHeight)
		{
			return (float)this.minimumHeight / (float)height;
		}
		if (height > this.maximumHeight)
		{
			return (float)this.maximumHeight / (float)height;
		}
		return 1f;
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x000451A7 File Offset: 0x000433A7
	protected virtual void Awake()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x000451B5 File Offset: 0x000433B5
	protected virtual void OnEnable()
	{
		UIRoot.list.Add(this);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x000451C2 File Offset: 0x000433C2
	protected virtual void OnDisable()
	{
		UIRoot.list.Remove(this);
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000451D0 File Offset: 0x000433D0
	protected virtual void Start()
	{
		UIOrthoCamera componentInChildren = base.GetComponentInChildren<UIOrthoCamera>();
		if (componentInChildren != null)
		{
			Debug.LogWarning("UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", componentInChildren);
			Camera component = componentInChildren.gameObject.GetComponent<Camera>();
			componentInChildren.enabled = false;
			if (component != null)
			{
				component.orthographicSize = 1f;
				return;
			}
		}
		else
		{
			this.UpdateScale(false);
		}
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x00045227 File Offset: 0x00043427
	private void Update()
	{
		this.UpdateScale(true);
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x00045230 File Offset: 0x00043430
	public void UpdateScale(bool updateAnchors = true)
	{
		if (this.mTrans != null)
		{
			float num = (float)this.activeHeight;
			if (num > 0f)
			{
				float num2 = 2f / num;
				Vector3 localScale = this.mTrans.localScale;
				if (Mathf.Abs(localScale.x - num2) > 1E-45f || Mathf.Abs(localScale.y - num2) > 1E-45f || Mathf.Abs(localScale.z - num2) > 1E-45f)
				{
					this.mTrans.localScale = new Vector3(num2, num2, num2);
					if (updateAnchors)
					{
						base.BroadcastMessage("UpdateAnchors", SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000452D0 File Offset: 0x000434D0
	public static void Broadcast(string funcName)
	{
		int i = 0;
		int count = UIRoot.list.Count;
		while (i < count)
		{
			UIRoot uiroot = UIRoot.list[i];
			if (uiroot != null)
			{
				uiroot.BroadcastMessage(funcName, SendMessageOptions.DontRequireReceiver);
			}
			i++;
		}
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x00045314 File Offset: 0x00043514
	public static void Broadcast(string funcName, object param)
	{
		if (param == null)
		{
			Debug.LogError("SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
			return;
		}
		int i = 0;
		int count = UIRoot.list.Count;
		while (i < count)
		{
			UIRoot uiroot = UIRoot.list[i];
			if (uiroot != null)
			{
				uiroot.BroadcastMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
			}
			i++;
		}
	}

	// Token: 0x04000752 RID: 1874
	public static List<UIRoot> list = new List<UIRoot>();

	// Token: 0x04000753 RID: 1875
	public UIRoot.Scaling scalingStyle;

	// Token: 0x04000754 RID: 1876
	public int manualWidth = 1280;

	// Token: 0x04000755 RID: 1877
	public int manualHeight = 720;

	// Token: 0x04000756 RID: 1878
	public int minimumHeight = 320;

	// Token: 0x04000757 RID: 1879
	public int maximumHeight = 1536;

	// Token: 0x04000758 RID: 1880
	public bool fitWidth;

	// Token: 0x04000759 RID: 1881
	public bool fitHeight = true;

	// Token: 0x0400075A RID: 1882
	public bool adjustByDPI;

	// Token: 0x0400075B RID: 1883
	public bool shrinkPortraitUI;

	// Token: 0x0400075C RID: 1884
	private Transform mTrans;

	// Token: 0x02000647 RID: 1607
	[DoNotObfuscateNGUI]
	public enum Scaling
	{
		// Token: 0x04004F83 RID: 20355
		Flexible,
		// Token: 0x04004F84 RID: 20356
		Constrained,
		// Token: 0x04004F85 RID: 20357
		ConstrainedOnMobiles
	}

	// Token: 0x02000648 RID: 1608
	[DoNotObfuscateNGUI]
	public enum Constraint
	{
		// Token: 0x04004F87 RID: 20359
		Fit,
		// Token: 0x04004F88 RID: 20360
		Fill,
		// Token: 0x04004F89 RID: 20361
		FitWidth,
		// Token: 0x04004F8A RID: 20362
		FitHeight
	}
}
