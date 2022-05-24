using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A48 RID: 6728 RVA: 0x00115DE5 File Offset: 0x00113FE5
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A49 RID: 6729 RVA: 0x00115DF8 File Offset: 0x00113FF8
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

	// Token: 0x04002B0A RID: 11018
	public Vector3 OriginalRotation;

	// Token: 0x04002B0B RID: 11019
	public float Rotate;

	// Token: 0x04002B0C RID: 11020
	public float Limit;

	// Token: 0x04002B0D RID: 11021
	public float Speed;

	// Token: 0x04002B0E RID: 11022
	private bool Down;
}
