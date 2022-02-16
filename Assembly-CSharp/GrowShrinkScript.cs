using System;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x0600182A RID: 6186 RVA: 0x000E4D88 File Offset: 0x000E2F88
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x0600182B RID: 6187 RVA: 0x000E4DAC File Offset: 0x000E2FAC
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

	// Token: 0x0600182C RID: 6188 RVA: 0x000E4F6C File Offset: 0x000E316C
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

	// Token: 0x04002310 RID: 8976
	public float FallSpeed;

	// Token: 0x04002311 RID: 8977
	public float Threshold = 1f;

	// Token: 0x04002312 RID: 8978
	public float Slowdown = 0.5f;

	// Token: 0x04002313 RID: 8979
	public float Strength = 1f;

	// Token: 0x04002314 RID: 8980
	public float Target = 1f;

	// Token: 0x04002315 RID: 8981
	public float Scale;

	// Token: 0x04002316 RID: 8982
	public float Speed = 5f;

	// Token: 0x04002317 RID: 8983
	public float Timer;

	// Token: 0x04002318 RID: 8984
	public bool Shrink;

	// Token: 0x04002319 RID: 8985
	public Vector3 OriginalPosition;
}
