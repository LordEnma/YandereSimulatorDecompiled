using System;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class BounceScript : MonoBehaviour
{
	// Token: 0x06000A5D RID: 2653 RVA: 0x0005C444 File Offset: 0x0005A644
	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x0005C480 File Offset: 0x0005A680
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

	// Token: 0x04000C09 RID: 3081
	public float StartingMotion;

	// Token: 0x04000C0A RID: 3082
	public float DecliningSpeed;

	// Token: 0x04000C0B RID: 3083
	public float Motion;

	// Token: 0x04000C0C RID: 3084
	public float PositionX;

	// Token: 0x04000C0D RID: 3085
	public float Speed;

	// Token: 0x04000C0E RID: 3086
	public Transform MyCamera;

	// Token: 0x04000C0F RID: 3087
	public bool Go;
}
