using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CF1 RID: 7409 RVA: 0x001590E0 File Offset: 0x001572E0
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x0400345C RID: 13404
	public float X;

	// Token: 0x0400345D RID: 13405
	public float Y;

	// Token: 0x0400345E RID: 13406
	public float Z;

	// Token: 0x0400345F RID: 13407
	private float RotationX;

	// Token: 0x04003460 RID: 13408
	private float RotationY;

	// Token: 0x04003461 RID: 13409
	private float RotationZ;
}
