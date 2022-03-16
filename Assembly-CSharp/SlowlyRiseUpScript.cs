using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CCB RID: 7371 RVA: 0x00156254 File Offset: 0x00154454
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

	// Token: 0x040033D9 RID: 13273
	public Transform Target;

	// Token: 0x040033DA RID: 13274
	public float Speed;

	// Token: 0x040033DB RID: 13275
	public bool Begin;
}
