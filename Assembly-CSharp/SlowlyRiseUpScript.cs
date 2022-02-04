using System;
using UnityEngine;

// Token: 0x0200042B RID: 1067
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CAA RID: 7338 RVA: 0x00153E78 File Offset: 0x00152078
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

	// Token: 0x04003375 RID: 13173
	public Transform Target;

	// Token: 0x04003376 RID: 13174
	public float Speed;

	// Token: 0x04003377 RID: 13175
	public bool Begin;
}
