using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A2D RID: 6701 RVA: 0x00114349 File Offset: 0x00112549
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A2E RID: 6702 RVA: 0x0011435C File Offset: 0x0011255C
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

	// Token: 0x04002ACA RID: 10954
	public Vector3 OriginalRotation;

	// Token: 0x04002ACB RID: 10955
	public float Rotate;

	// Token: 0x04002ACC RID: 10956
	public float Limit;

	// Token: 0x04002ACD RID: 10957
	public float Speed;

	// Token: 0x04002ACE RID: 10958
	private bool Down;
}
