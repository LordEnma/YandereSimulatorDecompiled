using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A23 RID: 6691 RVA: 0x00113839 File Offset: 0x00111A39
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A24 RID: 6692 RVA: 0x0011384C File Offset: 0x00111A4C
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

	// Token: 0x04002AA1 RID: 10913
	public Vector3 OriginalRotation;

	// Token: 0x04002AA2 RID: 10914
	public float Rotate;

	// Token: 0x04002AA3 RID: 10915
	public float Limit;

	// Token: 0x04002AA4 RID: 10916
	public float Speed;

	// Token: 0x04002AA5 RID: 10917
	private bool Down;
}
