using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CBC RID: 7356 RVA: 0x00154DC4 File Offset: 0x00152FC4
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

	// Token: 0x0400338E RID: 13198
	public Transform Target;

	// Token: 0x0400338F RID: 13199
	public float Speed;

	// Token: 0x04003390 RID: 13200
	public bool Begin;
}
