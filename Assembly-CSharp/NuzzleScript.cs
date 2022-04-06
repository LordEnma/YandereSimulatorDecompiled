using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A39 RID: 6713 RVA: 0x00114B0D File Offset: 0x00112D0D
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A3A RID: 6714 RVA: 0x00114B20 File Offset: 0x00112D20
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

	// Token: 0x04002AE0 RID: 10976
	public Vector3 OriginalRotation;

	// Token: 0x04002AE1 RID: 10977
	public float Rotate;

	// Token: 0x04002AE2 RID: 10978
	public float Limit;

	// Token: 0x04002AE3 RID: 10979
	public float Speed;

	// Token: 0x04002AE4 RID: 10980
	private bool Down;
}
