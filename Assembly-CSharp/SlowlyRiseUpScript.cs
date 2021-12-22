using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001C9E RID: 7326 RVA: 0x00151B1C File Offset: 0x0014FD1C
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

	// Token: 0x0400335C RID: 13148
	public Transform Target;

	// Token: 0x0400335D RID: 13149
	public float Speed;

	// Token: 0x0400335E RID: 13150
	public bool Begin;
}
