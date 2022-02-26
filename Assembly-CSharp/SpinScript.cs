using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CE2 RID: 7394 RVA: 0x00157C50 File Offset: 0x00155E50
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003411 RID: 13329
	public float X;

	// Token: 0x04003412 RID: 13330
	public float Y;

	// Token: 0x04003413 RID: 13331
	public float Z;

	// Token: 0x04003414 RID: 13332
	private float RotationX;

	// Token: 0x04003415 RID: 13333
	private float RotationY;

	// Token: 0x04003416 RID: 13334
	private float RotationZ;
}
