using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A0F RID: 6671 RVA: 0x00112111 File Offset: 0x00110311
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A10 RID: 6672 RVA: 0x00112124 File Offset: 0x00110324
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

	// Token: 0x04002A6B RID: 10859
	public Vector3 OriginalRotation;

	// Token: 0x04002A6C RID: 10860
	public float Rotate;

	// Token: 0x04002A6D RID: 10861
	public float Limit;

	// Token: 0x04002A6E RID: 10862
	public float Speed;

	// Token: 0x04002A6F RID: 10863
	private bool Down;
}
