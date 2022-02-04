using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A10 RID: 6672 RVA: 0x00112611 File Offset: 0x00110811
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A11 RID: 6673 RVA: 0x00112624 File Offset: 0x00110824
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

	// Token: 0x04002A72 RID: 10866
	public Vector3 OriginalRotation;

	// Token: 0x04002A73 RID: 10867
	public float Rotate;

	// Token: 0x04002A74 RID: 10868
	public float Limit;

	// Token: 0x04002A75 RID: 10869
	public float Speed;

	// Token: 0x04002A76 RID: 10870
	private bool Down;
}
