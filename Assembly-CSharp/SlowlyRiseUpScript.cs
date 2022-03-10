using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CBE RID: 7358 RVA: 0x00155348 File Offset: 0x00153548
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

	// Token: 0x040033A4 RID: 13220
	public Transform Target;

	// Token: 0x040033A5 RID: 13221
	public float Speed;

	// Token: 0x040033A6 RID: 13222
	public bool Begin;
}
