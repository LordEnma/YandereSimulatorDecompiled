using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001848 RID: 6216 RVA: 0x000E66C0 File Offset: 0x000E48C0
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001849 RID: 6217 RVA: 0x000E66E4 File Offset: 0x000E48E4
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

	// Token: 0x0600184A RID: 6218 RVA: 0x000E68A4 File Offset: 0x000E4AA4
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

	// Token: 0x04002357 RID: 9047
	public float FallSpeed;

	// Token: 0x04002358 RID: 9048
	public float Threshold = 1f;

	// Token: 0x04002359 RID: 9049
	public float Slowdown = 0.5f;

	// Token: 0x0400235A RID: 9050
	public float Strength = 1f;

	// Token: 0x0400235B RID: 9051
	public float Target = 1f;

	// Token: 0x0400235C RID: 9052
	public float Scale;

	// Token: 0x0400235D RID: 9053
	public float Speed = 5f;

	// Token: 0x0400235E RID: 9054
	public float Timer;

	// Token: 0x0400235F RID: 9055
	public bool Shrink;

	// Token: 0x04002360 RID: 9056
	public Vector3 OriginalPosition;
}
