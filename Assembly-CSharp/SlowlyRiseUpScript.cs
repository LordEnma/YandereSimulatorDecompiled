using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CA7 RID: 7335 RVA: 0x0015222C File Offset: 0x0015042C
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

	// Token: 0x04003369 RID: 13161
	public Transform Target;

	// Token: 0x0400336A RID: 13162
	public float Speed;

	// Token: 0x0400336B RID: 13163
	public bool Begin;
}
