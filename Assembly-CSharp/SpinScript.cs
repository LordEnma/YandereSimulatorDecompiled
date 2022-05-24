using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001D14 RID: 7444 RVA: 0x0015BAE4 File Offset: 0x00159CE4
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040034B2 RID: 13490
	public float X;

	// Token: 0x040034B3 RID: 13491
	public float Y;

	// Token: 0x040034B4 RID: 13492
	public float Z;

	// Token: 0x040034B5 RID: 13493
	private float RotationX;

	// Token: 0x040034B6 RID: 13494
	private float RotationY;

	// Token: 0x040034B7 RID: 13495
	private float RotationZ;
}
