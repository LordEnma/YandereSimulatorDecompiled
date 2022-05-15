using System;
using UnityEngine;

// Token: 0x020004BC RID: 1212
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FCF RID: 8143 RVA: 0x001C13C9 File Offset: 0x001BF5C9
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x001C13DC File Offset: 0x001BF5DC
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004273 RID: 17011
	public Vector3 Origin;
}
