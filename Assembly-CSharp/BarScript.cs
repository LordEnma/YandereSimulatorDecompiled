using System;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class BarScript : MonoBehaviour
{
	// Token: 0x0600214E RID: 8526 RVA: 0x001EAB85 File Offset: 0x001E8D85
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x001EABA8 File Offset: 0x001E8DA8
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

	// Token: 0x04004977 RID: 18807
	public float Speed;

	// Token: 0x04004978 RID: 18808
	public float Goal;
}
