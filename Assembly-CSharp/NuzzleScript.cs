using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A01 RID: 6657 RVA: 0x00111171 File Offset: 0x0010F371
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A02 RID: 6658 RVA: 0x00111184 File Offset: 0x0010F384
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

	// Token: 0x04002A37 RID: 10807
	public Vector3 OriginalRotation;

	// Token: 0x04002A38 RID: 10808
	public float Rotate;

	// Token: 0x04002A39 RID: 10809
	public float Limit;

	// Token: 0x04002A3A RID: 10810
	public float Speed;

	// Token: 0x04002A3B RID: 10811
	private bool Down;
}
