using System;
using UnityEngine;

// Token: 0x0200030A RID: 778
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001838 RID: 6200 RVA: 0x000E5E48 File Offset: 0x000E4048
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x000E5E6C File Offset: 0x000E406C
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

	// Token: 0x0600183A RID: 6202 RVA: 0x000E602C File Offset: 0x000E422C
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

	// Token: 0x04002344 RID: 9028
	public float FallSpeed;

	// Token: 0x04002345 RID: 9029
	public float Threshold = 1f;

	// Token: 0x04002346 RID: 9030
	public float Slowdown = 0.5f;

	// Token: 0x04002347 RID: 9031
	public float Strength = 1f;

	// Token: 0x04002348 RID: 9032
	public float Target = 1f;

	// Token: 0x04002349 RID: 9033
	public float Scale;

	// Token: 0x0400234A RID: 9034
	public float Speed = 5f;

	// Token: 0x0400234B RID: 9035
	public float Timer;

	// Token: 0x0400234C RID: 9036
	public bool Shrink;

	// Token: 0x0400234D RID: 9037
	public Vector3 OriginalPosition;
}
