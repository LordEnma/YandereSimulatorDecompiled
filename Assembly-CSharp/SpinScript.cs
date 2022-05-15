using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001D13 RID: 7443 RVA: 0x0015B828 File Offset: 0x00159A28
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040034AA RID: 13482
	public float X;

	// Token: 0x040034AB RID: 13483
	public float Y;

	// Token: 0x040034AC RID: 13484
	public float Z;

	// Token: 0x040034AD RID: 13485
	private float RotationX;

	// Token: 0x040034AE RID: 13486
	private float RotationY;

	// Token: 0x040034AF RID: 13487
	private float RotationZ;
}
