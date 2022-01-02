using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class BarScript : MonoBehaviour
{
	// Token: 0x060020FA RID: 8442 RVA: 0x001E3515 File Offset: 0x001E1715
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x001E3538 File Offset: 0x001E1738
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

	// Token: 0x04004881 RID: 18561
	public float Speed;

	// Token: 0x04004882 RID: 18562
	public float Goal;
}
