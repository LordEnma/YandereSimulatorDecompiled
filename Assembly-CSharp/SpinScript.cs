using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SpinScript : MonoBehaviour
{
	// Token: 0x06001CC4 RID: 7364 RVA: 0x00154970 File Offset: 0x00152B70
	private void Update()
	{
		this.RotationX += this.X * Time.deltaTime;
		this.RotationY += this.Y * Time.deltaTime;
		this.RotationZ += this.Z * Time.deltaTime;
		base.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
	}

	// Token: 0x040033DF RID: 13279
	public float X;

	// Token: 0x040033E0 RID: 13280
	public float Y;

	// Token: 0x040033E1 RID: 13281
	public float Z;

	// Token: 0x040033E2 RID: 13282
	private float RotationX;

	// Token: 0x040033E3 RID: 13283
	private float RotationY;

	// Token: 0x040033E4 RID: 13284
	private float RotationZ;
}
