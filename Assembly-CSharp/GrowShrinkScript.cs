using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x0600184C RID: 6220 RVA: 0x000E6BBC File Offset: 0x000E4DBC
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000E6BE0 File Offset: 0x000E4DE0
	private void Update()
	{
		this.Timer += Time.deltaTime * 2f;
		this.Scale += Time.deltaTime * (this.Strength * this.Speed) * 2f;
		if (!this.Shrink)
		{
			this.Strength += Time.deltaTime * this.Speed * 2f;
			if (this.Strength > this.Threshold)
			{
				this.Strength = this.Threshold;
			}
			if (this.Scale > this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = true;
			}
		}
		else
		{
			this.Strength -= Time.deltaTime * this.Speed * 2f;
			float num = this.Threshold * -1f;
			if (this.Strength < num)
			{
				this.Strength = num;
			}
			if (this.Scale < this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = false;
			}
		}
		if (this.Timer > 3.33333f)
		{
			this.FallSpeed += Time.deltaTime * 10f * 2f;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - this.FallSpeed * this.FallSpeed * 2f, base.transform.localPosition.z);
		}
		base.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
	}

	// Token: 0x0600184E RID: 6222 RVA: 0x000E6DA0 File Offset: 0x000E4FA0
	public void Return()
	{
		base.transform.localPosition = this.OriginalPosition;
		base.transform.localScale = Vector3.zero;
		this.FallSpeed = 0f;
		this.Threshold = 1f;
		this.Slowdown = 0.5f;
		this.Strength = 1f;
		this.Target = 1f;
		this.Scale = 0f;
		this.Speed = 5f;
		this.Timer = 0f;
		base.gameObject.SetActive(false);
	}

	// Token: 0x04002360 RID: 9056
	public float FallSpeed;

	// Token: 0x04002361 RID: 9057
	public float Threshold = 1f;

	// Token: 0x04002362 RID: 9058
	public float Slowdown = 0.5f;

	// Token: 0x04002363 RID: 9059
	public float Strength = 1f;

	// Token: 0x04002364 RID: 9060
	public float Target = 1f;

	// Token: 0x04002365 RID: 9061
	public float Scale;

	// Token: 0x04002366 RID: 9062
	public float Speed = 5f;

	// Token: 0x04002367 RID: 9063
	public float Timer;

	// Token: 0x04002368 RID: 9064
	public bool Shrink;

	// Token: 0x04002369 RID: 9065
	public Vector3 OriginalPosition;
}
