using System;
using UnityEngine;

// Token: 0x0200030C RID: 780
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001844 RID: 6212 RVA: 0x000E6458 File Offset: 0x000E4658
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x000E647C File Offset: 0x000E467C
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

	// Token: 0x06001846 RID: 6214 RVA: 0x000E663C File Offset: 0x000E483C
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

	// Token: 0x04002354 RID: 9044
	public float FallSpeed;

	// Token: 0x04002355 RID: 9045
	public float Threshold = 1f;

	// Token: 0x04002356 RID: 9046
	public float Slowdown = 0.5f;

	// Token: 0x04002357 RID: 9047
	public float Strength = 1f;

	// Token: 0x04002358 RID: 9048
	public float Target = 1f;

	// Token: 0x04002359 RID: 9049
	public float Scale;

	// Token: 0x0400235A RID: 9050
	public float Speed = 5f;

	// Token: 0x0400235B RID: 9051
	public float Timer;

	// Token: 0x0400235C RID: 9052
	public bool Shrink;

	// Token: 0x0400235D RID: 9053
	public Vector3 OriginalPosition;
}
