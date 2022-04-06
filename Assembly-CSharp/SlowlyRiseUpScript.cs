using System;
using UnityEngine;

// Token: 0x02000432 RID: 1074
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CDC RID: 7388 RVA: 0x001570D0 File Offset: 0x001552D0
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

	// Token: 0x040033F8 RID: 13304
	public Transform Target;

	// Token: 0x040033F9 RID: 13305
	public float Speed;

	// Token: 0x040033FA RID: 13306
	public bool Begin;
}
