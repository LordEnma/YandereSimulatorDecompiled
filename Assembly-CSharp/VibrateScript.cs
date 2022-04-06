using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FB6 RID: 8118 RVA: 0x001BE39D File Offset: 0x001BC59D
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x001BE3B0 File Offset: 0x001BC5B0
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x0400422F RID: 16943
	public Vector3 Origin;
}
