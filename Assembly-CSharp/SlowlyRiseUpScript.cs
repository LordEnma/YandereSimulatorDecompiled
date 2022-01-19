using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CA9 RID: 7337 RVA: 0x00153940 File Offset: 0x00151B40
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

	// Token: 0x0400336E RID: 13166
	public Transform Target;

	// Token: 0x0400336F RID: 13167
	public float Speed;

	// Token: 0x04003370 RID: 13168
	public bool Begin;
}
