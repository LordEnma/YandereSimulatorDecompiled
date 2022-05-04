using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class NuzzleScript : MonoBehaviour
{
	// Token: 0x06001A41 RID: 6721 RVA: 0x001152DD File Offset: 0x001134DD
	private void Start()
	{
		this.OriginalRotation = base.transform.localEulerAngles;
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x001152F0 File Offset: 0x001134F0
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

	// Token: 0x04002AF1 RID: 10993
	public Vector3 OriginalRotation;

	// Token: 0x04002AF2 RID: 10994
	public float Rotate;

	// Token: 0x04002AF3 RID: 10995
	public float Limit;

	// Token: 0x04002AF4 RID: 10996
	public float Speed;

	// Token: 0x04002AF5 RID: 10997
	private bool Down;
}
