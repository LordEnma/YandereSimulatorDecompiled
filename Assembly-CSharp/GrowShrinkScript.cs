using System;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x06001813 RID: 6163 RVA: 0x000E37B0 File Offset: 0x000E19B0
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x06001814 RID: 6164 RVA: 0x000E37D4 File Offset: 0x000E19D4
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

	// Token: 0x06001815 RID: 6165 RVA: 0x000E3994 File Offset: 0x000E1B94
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

	// Token: 0x040022D6 RID: 8918
	public float FallSpeed;

	// Token: 0x040022D7 RID: 8919
	public float Threshold = 1f;

	// Token: 0x040022D8 RID: 8920
	public float Slowdown = 0.5f;

	// Token: 0x040022D9 RID: 8921
	public float Strength = 1f;

	// Token: 0x040022DA RID: 8922
	public float Target = 1f;

	// Token: 0x040022DB RID: 8923
	public float Scale;

	// Token: 0x040022DC RID: 8924
	public float Speed = 5f;

	// Token: 0x040022DD RID: 8925
	public float Timer;

	// Token: 0x040022DE RID: 8926
	public bool Shrink;

	// Token: 0x040022DF RID: 8927
	public Vector3 OriginalPosition;
}
