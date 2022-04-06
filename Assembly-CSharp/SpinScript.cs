using System;
using UnityEngine;

// Token: 0x0200043E RID: 1086
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001D02 RID: 7426 RVA: 0x00159F5C File Offset: 0x0015815C
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x0400347B RID: 13435
	public float X;

	// Token: 0x0400347C RID: 13436
	public float Y;

	// Token: 0x0400347D RID: 13437
	public float Z;

	// Token: 0x0400347E RID: 13438
	private float RotationX;

	// Token: 0x0400347F RID: 13439
	private float RotationY;

	// Token: 0x04003480 RID: 13440
	private float RotationZ;
}
