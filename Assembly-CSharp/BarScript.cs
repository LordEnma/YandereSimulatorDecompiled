using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class BarScript : MonoBehaviour
{
	// Token: 0x0600215D RID: 8541 RVA: 0x001EBB11 File Offset: 0x001E9D11
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x0600215E RID: 8542 RVA: 0x001EBB34 File Offset: 0x001E9D34
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

	// Token: 0x0400498D RID: 18829
	public float Speed;

	// Token: 0x0400498E RID: 18830
	public float Goal;
}
