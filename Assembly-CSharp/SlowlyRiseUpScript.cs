using System;
using UnityEngine;

// Token: 0x0200042C RID: 1068
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CB3 RID: 7347 RVA: 0x00154318 File Offset: 0x00152518
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

	// Token: 0x0400337E RID: 13182
	public Transform Target;

	// Token: 0x0400337F RID: 13183
	public float Speed;

	// Token: 0x04003380 RID: 13184
	public bool Begin;
}
