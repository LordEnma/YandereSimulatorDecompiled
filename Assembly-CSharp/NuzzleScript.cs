using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A0B RID: 6667 RVA: 0x00111C49 File Offset: 0x0010FE49
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A0C RID: 6668 RVA: 0x00111C5C File Offset: 0x0010FE5C
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

	// Token: 0x04002A62 RID: 10850
	public Vector3 OriginalRotation;

	// Token: 0x04002A63 RID: 10851
	public float Rotate;

	// Token: 0x04002A64 RID: 10852
	public float Limit;

	// Token: 0x04002A65 RID: 10853
	public float Speed;

	// Token: 0x04002A66 RID: 10854
	private bool Down;
}
