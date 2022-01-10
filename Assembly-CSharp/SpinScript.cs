using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CCD RID: 7373 RVA: 0x001550B8 File Offset: 0x001532B8
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033EC RID: 13292
	public float X;

	// Token: 0x040033ED RID: 13293
	public float Y;

	// Token: 0x040033EE RID: 13294
	public float Z;

	// Token: 0x040033EF RID: 13295
	private float RotationX;

	// Token: 0x040033F0 RID: 13296
	private float RotationY;

	// Token: 0x040033F1 RID: 13297
	private float RotationZ;
}
