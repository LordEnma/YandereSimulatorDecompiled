using System;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class BounceScript : MonoBehaviour
{
	// Token: 0x06000A5C RID: 2652 RVA: 0x0005C1AE File Offset: 0x0005A3AE
	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x0005C1E8 File Offset: 0x0005A3E8
	private void Update()
	{
		base.transform.position += new Vector3(0f, this.Motion, 0f);
		this.Motion -= Time.deltaTime * this.DecliningSpeed;
		if (base.transform.position.y < 0.5f)
		{
			this.Motion = this.StartingMotion;
		}
		if (this.MyCamera != null && this.Go)
		{
			this.Speed += Time.deltaTime;
			this.PositionX = Mathf.Lerp(this.PositionX, -0.999f, Time.deltaTime * this.Speed);
			this.MyCamera.position = new Vector3(this.PositionX, 1f, -10f);
		}
	}

	// Token: 0x04000BFD RID: 3069
	public float StartingMotion;

	// Token: 0x04000BFE RID: 3070
	public float DecliningSpeed;

	// Token: 0x04000BFF RID: 3071
	public float Motion;

	// Token: 0x04000C00 RID: 3072
	public float PositionX;

	// Token: 0x04000C01 RID: 3073
	public float Speed;

	// Token: 0x04000C02 RID: 3074
	public Transform MyCamera;

	// Token: 0x04000C03 RID: 3075
	public bool Go;
}
