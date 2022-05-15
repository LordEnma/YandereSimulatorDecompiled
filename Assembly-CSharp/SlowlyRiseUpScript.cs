using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CED RID: 7405 RVA: 0x0015899C File Offset: 0x00156B9C
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

	// Token: 0x04003427 RID: 13351
	public Transform Target;

	// Token: 0x04003428 RID: 13352
	public float Speed;

	// Token: 0x04003429 RID: 13353
	public bool Begin;
}
