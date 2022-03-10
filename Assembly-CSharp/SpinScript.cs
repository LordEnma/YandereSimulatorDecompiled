using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CE4 RID: 7396 RVA: 0x001581D4 File Offset: 0x001563D4
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x04003427 RID: 13351
	public float X;

	// Token: 0x04003428 RID: 13352
	public float Y;

	// Token: 0x04003429 RID: 13353
	public float Z;

	// Token: 0x0400342A RID: 13354
	private float RotationX;

	// Token: 0x0400342B RID: 13355
	private float RotationY;

	// Token: 0x0400342C RID: 13356
	private float RotationZ;
}
