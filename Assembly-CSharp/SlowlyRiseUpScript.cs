using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CEE RID: 7406 RVA: 0x00158C58 File Offset: 0x00156E58
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

	// Token: 0x0400342F RID: 13359
	public Transform Target;

	// Token: 0x04003430 RID: 13360
	public float Speed;

	// Token: 0x04003431 RID: 13361
	public bool Begin;
}
