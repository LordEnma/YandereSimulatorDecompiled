using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CE0 RID: 7392 RVA: 0x001574E0 File Offset: 0x001556E0
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

	// Token: 0x04003403 RID: 13315
	public Transform Target;

	// Token: 0x04003404 RID: 13316
	public float Speed;

	// Token: 0x04003405 RID: 13317
	public bool Begin;
}
