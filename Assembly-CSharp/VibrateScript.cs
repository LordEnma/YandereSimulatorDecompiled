using System;
using UnityEngine;

// Token: 0x020004BB RID: 1211
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FC5 RID: 8133 RVA: 0x001C0135 File Offset: 0x001BE335
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FC6 RID: 8134 RVA: 0x001C0148 File Offset: 0x001BE348
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004255 RID: 16981
	public Vector3 Origin;
}
