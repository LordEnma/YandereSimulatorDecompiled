using System;
using UnityEngine;

// Token: 0x0200043D RID: 1085
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CFB RID: 7419 RVA: 0x00159C3C File Offset: 0x00157E3C
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003478 RID: 13432
	public float X;

	// Token: 0x04003479 RID: 13433
	public float Y;

	// Token: 0x0400347A RID: 13434
	public float Z;

	// Token: 0x0400347B RID: 13435
	private float RotationX;

	// Token: 0x0400347C RID: 13436
	private float RotationY;

	// Token: 0x0400347D RID: 13437
	private float RotationZ;
}
