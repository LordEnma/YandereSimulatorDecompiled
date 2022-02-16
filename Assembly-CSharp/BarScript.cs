using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class BarScript : MonoBehaviour
{
	// Token: 0x06002117 RID: 8471 RVA: 0x001E5DF5 File Offset: 0x001E3FF5
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001E5E18 File Offset: 0x001E4018
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

	// Token: 0x040048B9 RID: 18617
	public float Speed;

	// Token: 0x040048BA RID: 18618
	public float Goal;
}
