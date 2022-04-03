using System;
using UnityEngine;

// Token: 0x02000431 RID: 1073
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CD5 RID: 7381 RVA: 0x00156DB0 File Offset: 0x00154FB0
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

	// Token: 0x040033F5 RID: 13301
	public Transform Target;

	// Token: 0x040033F6 RID: 13302
	public float Speed;

	// Token: 0x040033F7 RID: 13303
	public bool Begin;
}
