using System;
using UnityEngine;

// Token: 0x020004BB RID: 1211
public class VibrateScript : MonoBehaviour
{
	// Token: 0x06001FC6 RID: 8134 RVA: 0x001C0231 File Offset: 0x001BE431
	private void Start()
	{
		this.Origin = base.transform.localPosition;
	}

	// Token: 0x06001FC7 RID: 8135 RVA: 0x001C0244 File Offset: 0x001BE444
	private void Update()
	{
		base.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(-5f, 5f), this.Origin.y + UnityEngine.Random.Range(-5f, 5f), base.transform.localPosition.z);
	}

	// Token: 0x04004255 RID: 16981
	public Vector3 Origin;
}
