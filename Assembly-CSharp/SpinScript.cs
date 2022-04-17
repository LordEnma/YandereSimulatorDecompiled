using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x0015A36C File Offset: 0x0015856C
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003486 RID: 13446
	public float X;

	// Token: 0x04003487 RID: 13447
	public float Y;

	// Token: 0x04003488 RID: 13448
	public float Z;

	// Token: 0x04003489 RID: 13449
	private float RotationX;

	// Token: 0x0400348A RID: 13450
	private float RotationY;

	// Token: 0x0400348B RID: 13451
	private float RotationZ;
}
