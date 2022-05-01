using System;
using UnityEngine;

// Token: 0x02000088 RID: 136
[AddComponentMenu("NGUI/Tween/Spring Position")]
public class SpringPosition : MonoBehaviour
{
	// Token: 0x06000555 RID: 1365 RVA: 0x00033E2A File Offset: 0x0003202A
	private void Start()
	{
		this.mTrans = base.transform;
		if (this.updateScrollView)
		{
			this.mSv = NGUITools.FindInParents<UIScrollView>(base.gameObject);
		}
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x00033E54 File Offset: 0x00032054
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

	// Token: 0x06000557 RID: 1367 RVA: 0x00033FEC File Offset: 0x000321EC
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

	// Token: 0x06000558 RID: 1368 RVA: 0x00034048 File Offset: 0x00032248
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

	// Token: 0x040005A0 RID: 1440
	public static SpringPosition current;

	// Token: 0x040005A1 RID: 1441
	public Vector3 target = Vector3.zero;

	// Token: 0x040005A2 RID: 1442
	public float strength = 10f;

	// Token: 0x040005A3 RID: 1443
	public bool worldSpace;

	// Token: 0x040005A4 RID: 1444
	public bool ignoreTimeScale;

	// Token: 0x040005A5 RID: 1445
	public bool updateScrollView;

	// Token: 0x040005A6 RID: 1446
	public SpringPosition.OnFinished onFinished;

	// Token: 0x040005A7 RID: 1447
	[SerializeField]
	[HideInInspector]
	private GameObject eventReceiver;

	// Token: 0x040005A8 RID: 1448
	[SerializeField]
	[HideInInspector]
	public string callWhenFinished;

	// Token: 0x040005A9 RID: 1449
	private Transform mTrans;

	// Token: 0x040005AA RID: 1450
	private float mThreshold;

	// Token: 0x040005AB RID: 1451
	private UIScrollView mSv;

	// Token: 0x02000612 RID: 1554
	// (Invoke) Token: 0x060025D8 RID: 9688
	public delegate void OnFinished();
}
