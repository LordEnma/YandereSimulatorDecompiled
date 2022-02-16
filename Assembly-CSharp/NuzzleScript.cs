using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A19 RID: 6681 RVA: 0x00112A4D File Offset: 0x00110C4D
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A1A RID: 6682 RVA: 0x00112A60 File Offset: 0x00110C60
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

	// Token: 0x04002A7B RID: 10875
	public Vector3 OriginalRotation;

	// Token: 0x04002A7C RID: 10876
	public float Rotate;

	// Token: 0x04002A7D RID: 10877
	public float Limit;

	// Token: 0x04002A7E RID: 10878
	public float Speed;

	// Token: 0x04002A7F RID: 10879
	private bool Down;
}
