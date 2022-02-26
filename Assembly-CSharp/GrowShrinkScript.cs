using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001833 RID: 6195 RVA: 0x000E566C File Offset: 0x000E386C
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001834 RID: 6196 RVA: 0x000E5690 File Offset: 0x000E3890
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

	// Token: 0x06001835 RID: 6197 RVA: 0x000E5850 File Offset: 0x000E3A50
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

	// Token: 0x0400231F RID: 8991
	public float FallSpeed;

	// Token: 0x04002320 RID: 8992
	public float Threshold = 1f;

	// Token: 0x04002321 RID: 8993
	public float Slowdown = 0.5f;

	// Token: 0x04002322 RID: 8994
	public float Strength = 1f;

	// Token: 0x04002323 RID: 8995
	public float Target = 1f;

	// Token: 0x04002324 RID: 8996
	public float Scale;

	// Token: 0x04002325 RID: 8997
	public float Speed = 5f;

	// Token: 0x04002326 RID: 8998
	public float Timer;

	// Token: 0x04002327 RID: 8999
	public bool Shrink;

	// Token: 0x04002328 RID: 9000
	public Vector3 OriginalPosition;
}
