using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CAC RID: 7340 RVA: 0x00154010 File Offset: 0x00152210
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

	// Token: 0x04003378 RID: 13176
	public Transform Target;

	// Token: 0x04003379 RID: 13177
	public float Speed;

	// Token: 0x0400337A RID: 13178
	public bool Begin;
}
