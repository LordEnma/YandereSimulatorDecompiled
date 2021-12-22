using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A09 RID: 6665 RVA: 0x0011196D File Offset: 0x0010FB6D
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A0A RID: 6666 RVA: 0x00111980 File Offset: 0x0010FB80
	private void Update()
	{
		if (!this.Down)
		{
			this.Rotate += Time.deltaTime * this.Speed;
			if (this.Rotate > this.Limit)
			{
				this.Down = true;
			}
		}
		else
		{
			this.Rotate -= Time.deltaTime * this.Speed;
			if (this.Rotate < -1f * this.Limit)
			{
				this.Down = false;
			}
		}
		base.transform.localEulerAngles = this.OriginalRotation + new Vector3(this.Rotate, 0f, 0f);
	}

	// Token: 0x04002A5E RID: 10846
	public Vector3 OriginalRotation;

	// Token: 0x04002A5F RID: 10847
	public float Rotate;

	// Token: 0x04002A60 RID: 10848
	public float Limit;

	// Token: 0x04002A61 RID: 10849
	public float Speed;

	// Token: 0x04002A62 RID: 10850
	private bool Down;
}
