using System;
using UnityEngine;

// Token: 0x02000036 RID: 54
[AddComponentMenu("NGUI/Examples/Pan With Mouse")]
public class PanWithMouse : MonoBehaviour
{
	// Token: 0x060000E0 RID: 224 RVA: 0x000127B7 File Offset: 0x000109B7
	private void Start()
	{
		this.mTrans = base.transform;
		this.mStart = this.mTrans.localRotation;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x000127D8 File Offset: 0x000109D8
	private void Update()
	{
		float deltaTime = RealTime.deltaTime;
		Vector3 vector = UICamera.lastEventPosition;
		float num = (float)Screen.width * 0.5f;
		float num2 = (float)Screen.height * 0.5f;
		if (this.range < 0.1f)
		{
			this.range = 0.1f;
		}
		float x = Mathf.Clamp((vector.x - num) / num / this.range, -1f, 1f);
		float y = Mathf.Clamp((vector.y - num2) / num2 / this.range, -1f, 1f);
		this.mRot = Vector2.Lerp(this.mRot, new Vector2(x, y), deltaTime * 5f);
		this.mTrans.localRotation = this.mStart * Quaternion.Euler(-this.mRot.y * this.degrees.y, this.mRot.x * this.degrees.x, 0f);
	}

	// Token: 0x040002A5 RID: 677
	public Vector2 degrees = new Vector2(5f, 3f);

	// Token: 0x040002A6 RID: 678
	public float range = 1f;

	// Token: 0x040002A7 RID: 679
	private Transform mTrans;

	// Token: 0x040002A8 RID: 680
	private Quaternion mStart;

	// Token: 0x040002A9 RID: 681
	private Vector2 mRot = Vector2.zero;
}
