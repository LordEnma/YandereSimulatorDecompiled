using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001851 RID: 6225 RVA: 0x000E6E88 File Offset: 0x000E5088
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001852 RID: 6226 RVA: 0x000E6EAC File Offset: 0x000E50AC
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

	// Token: 0x06001853 RID: 6227 RVA: 0x000E706C File Offset: 0x000E526C
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

	// Token: 0x0400236B RID: 9067
	public float FallSpeed;

	// Token: 0x0400236C RID: 9068
	public float Threshold = 1f;

	// Token: 0x0400236D RID: 9069
	public float Slowdown = 0.5f;

	// Token: 0x0400236E RID: 9070
	public float Strength = 1f;

	// Token: 0x0400236F RID: 9071
	public float Target = 1f;

	// Token: 0x04002370 RID: 9072
	public float Scale;

	// Token: 0x04002371 RID: 9073
	public float Speed = 5f;

	// Token: 0x04002372 RID: 9074
	public float Timer;

	// Token: 0x04002373 RID: 9075
	public bool Shrink;

	// Token: 0x04002374 RID: 9076
	public Vector3 OriginalPosition;
}
