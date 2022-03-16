using System;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class BounceScript : MonoBehaviour
{
	// Token: 0x06000A5E RID: 2654 RVA: 0x0005C584 File Offset: 0x0005A784
	private void Start()
	{
		this.StartingMotion += UnityEngine.Random.Range(-0.001f, 0.001f);
		this.DecliningSpeed += UnityEngine.Random.Range(-0.001f, 0.001f);
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x0005C5C0 File Offset: 0x0005A7C0
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

	// Token: 0x04000C0F RID: 3087
	public float StartingMotion;

	// Token: 0x04000C10 RID: 3088
	public float DecliningSpeed;

	// Token: 0x04000C11 RID: 3089
	public float Motion;

	// Token: 0x04000C12 RID: 3090
	public float PositionX;

	// Token: 0x04000C13 RID: 3091
	public float Speed;

	// Token: 0x04000C14 RID: 3092
	public Transform MyCamera;

	// Token: 0x04000C15 RID: 3093
	public bool Go;
}
