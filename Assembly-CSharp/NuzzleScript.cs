using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A22 RID: 6690 RVA: 0x00113461 File Offset: 0x00111661
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x00113474 File Offset: 0x00111674
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

	// Token: 0x04002A8B RID: 10891
	public Vector3 OriginalRotation;

	// Token: 0x04002A8C RID: 10892
	public float Rotate;

	// Token: 0x04002A8D RID: 10893
	public float Limit;

	// Token: 0x04002A8E RID: 10894
	public float Speed;

	// Token: 0x04002A8F RID: 10895
	private bool Down;
}
