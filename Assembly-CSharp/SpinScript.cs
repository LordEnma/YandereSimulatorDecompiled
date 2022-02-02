using System;
using UnityEngine;

// Token: 0x02000437 RID: 1079
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CD0 RID: 7376 RVA: 0x00156C00 File Offset: 0x00154E00
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033F7 RID: 13303
	public float X;

	// Token: 0x040033F8 RID: 13304
	public float Y;

	// Token: 0x040033F9 RID: 13305
	public float Z;

	// Token: 0x040033FA RID: 13306
	private float RotationX;

	// Token: 0x040033FB RID: 13307
	private float RotationY;

	// Token: 0x040033FC RID: 13308
	private float RotationZ;
}
