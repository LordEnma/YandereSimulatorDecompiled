using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SlowlyRiseUpScript : MonoBehaviour
{
	// Token: 0x06001CA0 RID: 7328 RVA: 0x00151F28 File Offset: 0x00150128
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

	// Token: 0x04003363 RID: 13155
	public Transform Target;

	// Token: 0x04003364 RID: 13156
	public float Speed;

	// Token: 0x04003365 RID: 13157
	public bool Begin;
}
