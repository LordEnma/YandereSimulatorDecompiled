using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CD9 RID: 7385 RVA: 0x001571A4 File Offset: 0x001553A4
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003401 RID: 13313
	public float X;

	// Token: 0x04003402 RID: 13314
	public float Y;

	// Token: 0x04003403 RID: 13315
	public float Z;

	// Token: 0x04003404 RID: 13316
	private float RotationX;

	// Token: 0x04003405 RID: 13317
	private float RotationY;

	// Token: 0x04003406 RID: 13318
	private float RotationZ;
}
