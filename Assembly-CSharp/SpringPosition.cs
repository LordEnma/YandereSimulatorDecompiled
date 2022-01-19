using System;
using UnityEngine;

// Token: 0x02000088 RID: 136
[AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : MonoBehaviour
{
	// Token: 0x06000555 RID: 1365 RVA: 0x00033B3A File Offset: 0x00031D3A
	private void Start()
	{
		this.mTrans = base.transform;
		if (this.updateScrollView)
		{
			this.mSv = NGUITools.FindInParents<UIScrollView>(base.gameObject);
		}
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00033B64 File Offset: 0x00031D64
	private void Update()
	{
		float deltaTime = this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime;
		if (this.worldSpace)
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.position).sqrMagnitude * 0.001f;
			}
			this.mTrans.position = NGUIMath.SpringLerp(this.mTrans.position, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.position).sqrMagnitude)
			{
				this.mTrans.position = this.target;
				this.NotifyListeners();
				base.enabled = false;
			}
		}
		else
		{
			if (this.mThreshold == 0f)
			{
				this.mThreshold = (this.target - this.mTrans.localPosition).sqrMagnitude * 1E-05f;
			}
			this.mTrans.localPosition = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
			if (this.mThreshold >= (this.target - this.mTrans.localPosition).sqrMagnitude)
			{
				this.mTrans.localPosition = this.target;
				this.NotifyListeners();
				base.enabled = false;
			}
		}
		if (this.mSv != null)
		{
			this.mSv.UpdateScrollbars(true);
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x00033CFC File Offset: 0x00031EFC
	private void NotifyListeners()
	{
		SpringPosition.current = this;
		if (this.onFinished != null)
		{
			this.onFinished();
		}
		if (this.eventReceiver != null && !string.IsNullOrEmpty(this.callWhenFinished))
		{
			this.eventReceiver.SendMessage(this.callWhenFinished, this, SendMessageOptions.DontRequireReceiver);
		}
		SpringPosition.current = null;
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x00033D58 File Offset: 0x00031F58
	public static SpringPosition Begin(GameObject go, Vector3 pos, float strength)
	{
		SpringPosition springPosition = go.GetComponent<SpringPosition>();
		if (springPosition == null)
		{
			springPosition = go.AddComponent<SpringPosition>();
		}
		springPosition.target = pos;
		springPosition.strength = strength;
		springPosition.onFinished = null;
		if (!springPosition.enabled)
		{
			springPosition.enabled = true;
		}
		return springPosition;
	}

	// Token: 0x04000594 RID: 1428
	public static SpringPosition current;

	// Token: 0x04000595 RID: 1429
	public Vector3 target = Vector3.zero;

	// Token: 0x04000596 RID: 1430
	public float strength = 10f;

	// Token: 0x04000597 RID: 1431
	public bool worldSpace;

	// Token: 0x04000598 RID: 1432
	public bool ignoreTimeScale;

	// Token: 0x04000599 RID: 1433
	public bool updateScrollView;

	// Token: 0x0400059A RID: 1434
	public SpringPosition.OnFinished onFinished;

	// Token: 0x0400059B RID: 1435
	[SerializeField]
	[HideInInspector]
	private GameObject eventReceiver;

	// Token: 0x0400059C RID: 1436
	[SerializeField]
	[HideInInspector]
	public string callWhenFinished;

	// Token: 0x0400059D RID: 1437
	private Transform mTrans;

	// Token: 0x0400059E RID: 1438
	private float mThreshold;

	// Token: 0x0400059F RID: 1439
	private UIScrollView mSv;

	// Token: 0x0200060A RID: 1546
	// (Invoke) Token: 0x0600258D RID: 9613
	public delegate void OnFinished();
}
