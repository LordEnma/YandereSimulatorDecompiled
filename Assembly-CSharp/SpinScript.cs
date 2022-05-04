using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001D0D RID: 7437 RVA: 0x0015AB74 File Offset: 0x00158D74
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003495 RID: 13461
	public float X;

	// Token: 0x04003496 RID: 13462
	public float Y;

	// Token: 0x04003497 RID: 13463
	public float Z;

	// Token: 0x04003498 RID: 13464
	private float RotationX;

	// Token: 0x04003499 RID: 13465
	private float RotationY;

	// Token: 0x0400349A RID: 13466
	private float RotationZ;
}
