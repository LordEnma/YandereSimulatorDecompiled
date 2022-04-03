using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A33 RID: 6707 RVA: 0x001149A1 File Offset: 0x00112BA1
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x001149B4 File Offset: 0x00112BB4
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

	// Token: 0x04002ADD RID: 10973
	public Vector3 OriginalRotation;

	// Token: 0x04002ADE RID: 10974
	public float Rotate;

	// Token: 0x04002ADF RID: 10975
	public float Limit;

	// Token: 0x04002AE0 RID: 10976
	public float Speed;

	// Token: 0x04002AE1 RID: 10977
	private bool Down;
}
