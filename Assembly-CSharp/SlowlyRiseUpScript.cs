using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CE7 RID: 7399 RVA: 0x00157D1C File Offset: 0x00155F1C
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			this.Speed += Time.deltaTime;
			base.transform.position = Vector3.Lerp(base.transform.position, this.Target.position, Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x04003412 RID: 13330
	public Transform Target;

	// Token: 0x04003413 RID: 13331
	public float Speed;

	// Token: 0x04003414 RID: 13332
	public bool Begin;
}
