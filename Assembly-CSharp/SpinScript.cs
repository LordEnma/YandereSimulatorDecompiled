using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CC6 RID: 7366 RVA: 0x00154DB4 File Offset: 0x00152FB4
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033E6 RID: 13286
	public float X;

	// Token: 0x040033E7 RID: 13287
	public float Y;

	// Token: 0x040033E8 RID: 13288
	public float Z;

	// Token: 0x040033E9 RID: 13289
	private float RotationX;

	// Token: 0x040033EA RID: 13290
	private float RotationY;

	// Token: 0x040033EB RID: 13291
	private float RotationZ;
}
