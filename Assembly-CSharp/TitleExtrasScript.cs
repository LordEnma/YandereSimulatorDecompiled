using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EB9 RID: 7865 RVA: 0x001B0574 File Offset: 0x001AE774
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EBA RID: 7866 RVA: 0x001B05AC File Offset: 0x001AE7AC
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04003F8B RID: 16267
	public bool Show;
}
