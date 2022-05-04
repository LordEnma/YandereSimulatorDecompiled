using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : MonoBehaviour
{
	// Token: 0x0600046A RID: 1130 RVA: 0x0002CAD5 File Offset: 0x0002ACD5
	private void Start()
	{
		this.mPanel = base.GetComponent<UIPanel>();
		this.mDrag = base.GetComponent<UIScrollView>();
		this.mTrans = base.transform;
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0002CAFB File Offset: 0x0002ACFB
	private void Update()
	{
		this.AdvanceTowardsPosition();
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0002CB04 File Offset: 0x0002AD04
	protected virtual void AdvanceTowardsPosition()
	{
		this.mDelta += RealTime.deltaTime;
		bool flag = false;
		Vector3 localPosition = this.mTrans.localPosition;
		Vector3 vector = NGUIMath.SpringLerp(localPosition, this.target, this.strength, this.mDelta);
		if ((localPosition - this.target).sqrMagnitude < 0.01f)
		{
			vector = this.target;
			base.enabled = false;
			flag = true;
			this.mDelta = 0f;
		}
		else
		{
			vector.x = Mathf.Round(vector.x);
			vector.y = Mathf.Round(vector.y);
			vector.z = Mathf.Round(vector.z);
			if ((vector - localPosition).sqrMagnitude < 0.01f)
			{
				return;
			}
			this.mDelta = 0f;
		}
		this.mTrans.localPosition = vector;
		Vector3 vector2 = vector - localPosition;
		Vector2 clipOffset = this.mPanel.clipOffset;
		clipOffset.x -= vector2.x;
		clipOffset.y -= vector2.y;
		this.mPanel.clipOffset = clipOffset;
		if (this.mDrag != null)
		{
			this.mDrag.UpdateScrollbars(false);
		}
		if (flag && this.onFinished != null)
		{
			SpringPanel.current = this;
			this.onFinished();
			SpringPanel.current = null;
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0002CC68 File Offset: 0x0002AE68
	public static SpringPanel Begin(GameObject go, Vector3 pos, float strength)
	{
		SpringPanel springPanel = go.GetComponent<SpringPanel>();
		if (springPanel == null)
		{
			springPanel = go.AddComponent<SpringPanel>();
		}
		springPanel.target = pos;
		springPanel.strength = strength;
		springPanel.onFinished = null;
		springPanel.enabled = true;
		return springPanel;
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0002CCAC File Offset: 0x0002AEAC
	public static SpringPanel Stop(GameObject go)
	{
		SpringPanel component = go.GetComponent<SpringPanel>();
		if (component != null && component.enabled)
		{
			if (component.onFinished != null)
			{
				component.onFinished();
			}
			component.enabled = false;
		}
		return component;
	}

	// Token: 0x04000502 RID: 1282
	public static SpringPanel current;

	// Token: 0x04000503 RID: 1283
	public Vector3 target = Vector3.zero;

	// Token: 0x04000504 RID: 1284
	public float strength = 10f;

	// Token: 0x04000505 RID: 1285
	public SpringPanel.OnFinished onFinished;

	// Token: 0x04000506 RID: 1286
	[NonSerialized]
	private UIPanel mPanel;

	// Token: 0x04000507 RID: 1287
	[NonSerialized]
	private Transform mTrans;

	// Token: 0x04000508 RID: 1288
	[NonSerialized]
	private UIScrollView mDrag;

	// Token: 0x04000509 RID: 1289
	[NonSerialized]
	private float mDelta;

	// Token: 0x020005FB RID: 1531
	// (Invoke) Token: 0x0600259C RID: 9628
	public delegate void OnFinished();
}
