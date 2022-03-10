using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001833 RID: 6195 RVA: 0x000E599C File Offset: 0x000E3B9C
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001834 RID: 6196 RVA: 0x000E59C0 File Offset: 0x000E3BC0
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

	// Token: 0x06001835 RID: 6197 RVA: 0x000E5B80 File Offset: 0x000E3D80
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

	// Token: 0x04002333 RID: 9011
	public float FallSpeed;

	// Token: 0x04002334 RID: 9012
	public float Threshold = 1f;

	// Token: 0x04002335 RID: 9013
	public float Slowdown = 0.5f;

	// Token: 0x04002336 RID: 9014
	public float Strength = 1f;

	// Token: 0x04002337 RID: 9015
	public float Target = 1f;

	// Token: 0x04002338 RID: 9016
	public float Scale;

	// Token: 0x04002339 RID: 9017
	public float Speed = 5f;

	// Token: 0x0400233A RID: 9018
	public float Timer;

	// Token: 0x0400233B RID: 9019
	public bool Shrink;

	// Token: 0x0400233C RID: 9020
	public Vector3 OriginalPosition;
}
