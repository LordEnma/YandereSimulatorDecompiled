using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001C96 RID: 7318 RVA: 0x001511F8 File Offset: 0x0014F3F8
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

	// Token: 0x04003331 RID: 13105
	public Transform Target;

	// Token: 0x04003332 RID: 13106
	public float Speed;

	// Token: 0x04003333 RID: 13107
	public bool Begin;
}
