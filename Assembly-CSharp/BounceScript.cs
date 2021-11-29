using System;
using UnityEngine;

// Token: 0x020000F3 RID: 243
public class BounceScript : MonoBehaviour
{
	// Token: 0x06000A59 RID: 2649 RVA: 0x0005C022 File Offset: 0x0005A222
	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x0005C05C File Offset: 0x0005A25C
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

	// Token: 0x04000BFB RID: 3067
	public float StartingMotion;

	// Token: 0x04000BFC RID: 3068
	public float DecliningSpeed;

	// Token: 0x04000BFD RID: 3069
	public float Motion;

	// Token: 0x04000BFE RID: 3070
	public float PositionX;

	// Token: 0x04000BFF RID: 3071
	public float Speed;

	// Token: 0x04000C00 RID: 3072
	public Transform MyCamera;

	// Token: 0x04000C01 RID: 3073
	public bool Go;
}
