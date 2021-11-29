using System;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class BarScript : MonoBehaviour
{
	// Token: 0x060020E6 RID: 8422 RVA: 0x001E17F1 File Offset: 0x001DF9F1
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E1814 File Offset: 0x001DFA14
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

	// Token: 0x04004839 RID: 18489
	public float Speed;

	// Token: 0x0400483A RID: 18490
	public float Goal;
}
