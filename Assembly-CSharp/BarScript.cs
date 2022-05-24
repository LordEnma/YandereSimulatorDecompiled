using System;
using UnityEngine;

// Token: 0x02000509 RID: 1289
public class BarScript : MonoBehaviour
{
	// Token: 0x06002172 RID: 8562 RVA: 0x001EEC51 File Offset: 0x001ECE51
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002173 RID: 8563 RVA: 0x001EEC74 File Offset: 0x001ECE74
	private void Update()
	{
		if (this.Goal == 0f)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x + this.Speed * Time.deltaTime, 1f, 1f);
			if ((double)base.transform.localScale.x > 0.1)
			{
				base.transform.localScale = new Vector3(0f, 1f, 1f);
				return;
			}
		}
		else
		{
			this.Speed += Time.deltaTime;
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(this.Goal, 1f, 1f), Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x040049D3 RID: 18899
	public float Speed;

	// Token: 0x040049D4 RID: 18900
	public float Goal;
}
