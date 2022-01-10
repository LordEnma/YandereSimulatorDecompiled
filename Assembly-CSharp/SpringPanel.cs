using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : MonoBehaviour
{
	// Token: 0x0600046A RID: 1130 RVA: 0x0002C7ED File Offset: 0x0002A9ED
	private void Start()
	{
		this.mPanel = base.GetComponent<UIPanel>();
		this.mDrag = base.GetComponent<UIScrollView>();
		this.mTrans = base.transform;
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0002C813 File Offset: 0x0002AA13
	private void Update()
	{
		this.AdvanceTowardsPosition();
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0002C81C File Offset: 0x0002AA1C
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

	// Token: 0x0600046D RID: 1133 RVA: 0x0002C980 File Offset: 0x0002AB80
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

	// Token: 0x0600046E RID: 1134 RVA: 0x0002C9C4 File Offset: 0x0002ABC4
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

	// Token: 0x040004F5 RID: 1269
	public static SpringPanel current;

	// Token: 0x040004F6 RID: 1270
	public Vector3 target = Vector3.zero;

	// Token: 0x040004F7 RID: 1271
	public float strength = 10f;

	// Token: 0x040004F8 RID: 1272
	public SpringPanel.OnFinished onFinished;

	// Token: 0x040004F9 RID: 1273
	[NonSerialized]
	private UIPanel mPanel;

	// Token: 0x040004FA RID: 1274
	[NonSerialized]
	private Transform mTrans;

	// Token: 0x040004FB RID: 1275
	[NonSerialized]
	private UIScrollView mDrag;

	// Token: 0x040004FC RID: 1276
	[NonSerialized]
	private float mDelta;

	// Token: 0x020005F2 RID: 1522
	// (Invoke) Token: 0x0600254E RID: 9550
	public delegate void OnFinished();
}
