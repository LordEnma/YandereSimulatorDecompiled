using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A8 RID: 168
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Root")]
public class UIRoot : MonoBehaviour
{
	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06000841 RID: 2113 RVA: 0x00044C61 File Offset: 0x00042E61
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
	// (get) Token: 0x06000842 RID: 2114 RVA: 0x00044C84 File Offset: 0x00042E84
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
	// (get) Token: 0x06000843 RID: 2115 RVA: 0x00044CA0 File Offset: 0x00042EA0
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
	// (get) Token: 0x06000844 RID: 2116 RVA: 0x00044E04 File Offset: 0x00043004
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

	// Token: 0x06000845 RID: 2117 RVA: 0x00044E34 File Offset: 0x00043034
	public static float GetPixelSizeAdjustment(GameObject go)
	{
		UIRoot uiroot = NGUITools.FindInParents<UIRoot>(go);
		if (!(uiroot != null))
		{
			return 1f;
		}
		return uiroot.pixelSizeAdjustment;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00044E60 File Offset: 0x00043060
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

	// Token: 0x06000847 RID: 2119 RVA: 0x00044EB7 File Offset: 0x000430B7
	protected virtual void Awake()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x00044EC5 File Offset: 0x000430C5
	protected virtual void OnEnable()
	{
		UIRoot.list.Add(this);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00044ED2 File Offset: 0x000430D2
	protected virtual void OnDisable()
	{
		UIRoot.list.Remove(this);
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x00044EE0 File Offset: 0x000430E0
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

	// Token: 0x0600084B RID: 2123 RVA: 0x00044F37 File Offset: 0x00043137
	private void Update()
	{
		this.UpdateScale(true);
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x00044F40 File Offset: 0x00043140
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

	// Token: 0x0600084D RID: 2125 RVA: 0x00044FE0 File Offset: 0x000431E0
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

	// Token: 0x0600084E RID: 2126 RVA: 0x00045024 File Offset: 0x00043224
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

	// Token: 0x04000747 RID: 1863
	public static List<UIRoot> list = new List<UIRoot>();

	// Token: 0x04000748 RID: 1864
	public UIRoot.Scaling scalingStyle;

	// Token: 0x04000749 RID: 1865
	public int manualWidth = 1280;

	// Token: 0x0400074A RID: 1866
	public int manualHeight = 720;

	// Token: 0x0400074B RID: 1867
	public int minimumHeight = 320;

	// Token: 0x0400074C RID: 1868
	public int maximumHeight = 1536;

	// Token: 0x0400074D RID: 1869
	public bool fitWidth;

	// Token: 0x0400074E RID: 1870
	public bool fitHeight = true;

	// Token: 0x0400074F RID: 1871
	public bool adjustByDPI;

	// Token: 0x04000750 RID: 1872
	public bool shrinkPortraitUI;

	// Token: 0x04000751 RID: 1873
	private Transform mTrans;

	// Token: 0x02000638 RID: 1592
	[DoNotObfuscateNGUI]
	public enum Scaling
	{
		// Token: 0x04004E61 RID: 20065
		Flexible,
		// Token: 0x04004E62 RID: 20066
		Constrained,
		// Token: 0x04004E63 RID: 20067
		ConstrainedOnMobiles
	}

	// Token: 0x02000639 RID: 1593
	[DoNotObfuscateNGUI]
	public enum Constraint
	{
		// Token: 0x04004E65 RID: 20069
		Fit,
		// Token: 0x04004E66 RID: 20070
		Fill,
		// Token: 0x04004E67 RID: 20071
		FitWidth,
		// Token: 0x04004E68 RID: 20072
		FitHeight
	}
}
