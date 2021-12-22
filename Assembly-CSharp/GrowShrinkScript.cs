using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x0600181A RID: 6170 RVA: 0x000E3F70 File Offset: 0x000E2170
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x000E3F94 File Offset: 0x000E2194
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

	// Token: 0x0600181C RID: 6172 RVA: 0x000E4154 File Offset: 0x000E2354
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

	// Token: 0x040022F6 RID: 8950
	public float FallSpeed;

	// Token: 0x040022F7 RID: 8951
	public float Threshold = 1f;

	// Token: 0x040022F8 RID: 8952
	public float Slowdown = 0.5f;

	// Token: 0x040022F9 RID: 8953
	public float Strength = 1f;

	// Token: 0x040022FA RID: 8954
	public float Target = 1f;

	// Token: 0x040022FB RID: 8955
	public float Scale;

	// Token: 0x040022FC RID: 8956
	public float Speed = 5f;

	// Token: 0x040022FD RID: 8957
	public float Timer;

	// Token: 0x040022FE RID: 8958
	public bool Shrink;

	// Token: 0x040022FF RID: 8959
	public Vector3 OriginalPosition;
}
