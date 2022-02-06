using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CD2 RID: 7378 RVA: 0x00156E9C File Offset: 0x0015509C
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033FB RID: 13307
	public float X;

	// Token: 0x040033FC RID: 13308
	public float Y;

	// Token: 0x040033FD RID: 13309
	public float Z;

	// Token: 0x040033FE RID: 13310
	private float RotationX;

	// Token: 0x040033FF RID: 13311
	private float RotationY;

	// Token: 0x04003400 RID: 13312
	private float RotationZ;
}
