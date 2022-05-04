using System;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class BarScript : MonoBehaviour
{
	// Token: 0x06002167 RID: 8551 RVA: 0x001ED099 File Offset: 0x001EB299
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x001ED0BC File Offset: 0x001EB2BC
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

	// Token: 0x040049A3 RID: 18851
	public float Speed;

	// Token: 0x040049A4 RID: 18852
	public float Goal;
}
