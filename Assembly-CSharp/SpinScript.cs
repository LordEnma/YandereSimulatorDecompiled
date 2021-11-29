using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CBC RID: 7356 RVA: 0x0015404C File Offset: 0x0015224C
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033B4 RID: 13236
	public float X;

	// Token: 0x040033B5 RID: 13237
	public float Y;

	// Token: 0x040033B6 RID: 13238
	public float Z;

	// Token: 0x040033B7 RID: 13239
	private float RotationX;

	// Token: 0x040033B8 RID: 13240
	private float RotationY;

	// Token: 0x040033B9 RID: 13241
	private float RotationZ;
}
