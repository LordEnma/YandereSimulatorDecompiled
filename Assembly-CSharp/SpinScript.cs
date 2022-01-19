using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CCF RID: 7375 RVA: 0x001567CC File Offset: 0x001549CC
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033F1 RID: 13297
	public float X;

	// Token: 0x040033F2 RID: 13298
	public float Y;

	// Token: 0x040033F3 RID: 13299
	public float Z;

	// Token: 0x040033F4 RID: 13300
	private float RotationX;

	// Token: 0x040033F5 RID: 13301
	private float RotationY;

	// Token: 0x040033F6 RID: 13302
	private float RotationZ;
}
