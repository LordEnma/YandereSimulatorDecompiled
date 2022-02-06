using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A12 RID: 6674 RVA: 0x00112729 File Offset: 0x00110929
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A13 RID: 6675 RVA: 0x0011273C File Offset: 0x0011093C
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

	// Token: 0x04002A75 RID: 10869
	public Vector3 OriginalRotation;

	// Token: 0x04002A76 RID: 10870
	public float Rotate;

	// Token: 0x04002A77 RID: 10871
	public float Limit;

	// Token: 0x04002A78 RID: 10872
	public float Speed;

	// Token: 0x04002A79 RID: 10873
	private bool Down;
}
