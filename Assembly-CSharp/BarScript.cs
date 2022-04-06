using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class BarScript : MonoBehaviour
{
	// Token: 0x06002156 RID: 8534 RVA: 0x001EB0B5 File Offset: 0x001E92B5
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 1f, 1f);
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x001EB0D8 File Offset: 0x001E92D8
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

	// Token: 0x0400497B RID: 18811
	public float Speed;

	// Token: 0x0400497C RID: 18812
	public float Goal;
}
