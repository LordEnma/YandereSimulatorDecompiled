using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EC0 RID: 7872 RVA: 0x001B0A2C File Offset: 0x001AEC2C
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EC1 RID: 7873 RVA: 0x001B0A64 File Offset: 0x001AEC64
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F94 RID: 16276
	public bool Show;
}
