using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A47 RID: 6727 RVA: 0x00115BB5 File Offset: 0x00113DB5
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x00115BC8 File Offset: 0x00113DC8
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

	// Token: 0x04002B03 RID: 11011
	public Vector3 OriginalRotation;

	// Token: 0x04002B04 RID: 11012
	public float Rotate;

	// Token: 0x04002B05 RID: 11013
	public float Limit;

	// Token: 0x04002B06 RID: 11014
	public float Speed;

	// Token: 0x04002B07 RID: 11015
	private bool Down;
}
