using System;
using UnityEngine;

// Token: 0x02000308 RID: 776
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001820 RID: 6176 RVA: 0x000E4568 File Offset: 0x000E2768
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001821 RID: 6177 RVA: 0x000E458C File Offset: 0x000E278C
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

	// Token: 0x06001822 RID: 6178 RVA: 0x000E474C File Offset: 0x000E294C
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

	// Token: 0x040022FE RID: 8958
	public float FallSpeed;

	// Token: 0x040022FF RID: 8959
	public float Threshold = 1f;

	// Token: 0x04002300 RID: 8960
	public float Slowdown = 0.5f;

	// Token: 0x04002301 RID: 8961
	public float Strength = 1f;

	// Token: 0x04002302 RID: 8962
	public float Target = 1f;

	// Token: 0x04002303 RID: 8963
	public float Scale;

	// Token: 0x04002304 RID: 8964
	public float Speed = 5f;

	// Token: 0x04002305 RID: 8965
	public float Timer;

	// Token: 0x04002306 RID: 8966
	public bool Shrink;

	// Token: 0x04002307 RID: 8967
	public Vector3 OriginalPosition;
}
