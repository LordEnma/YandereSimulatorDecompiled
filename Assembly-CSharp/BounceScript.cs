using System;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class BounceScript : MonoBehaviour
{
	// Token: 0x06000A60 RID: 2656 RVA: 0x0005CB88 File Offset: 0x0005AD88
	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x0005CBC4 File Offset: 0x0005ADC4
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

	// Token: 0x04000C17 RID: 3095
	public float StartingMotion;

	// Token: 0x04000C18 RID: 3096
	public float DecliningSpeed;

	// Token: 0x04000C19 RID: 3097
	public float Motion;

	// Token: 0x04000C1A RID: 3098
	public float PositionX;

	// Token: 0x04000C1B RID: 3099
	public float Speed;

	// Token: 0x04000C1C RID: 3100
	public Transform MyCamera;

	// Token: 0x04000C1D RID: 3101
	public bool Go;
}
