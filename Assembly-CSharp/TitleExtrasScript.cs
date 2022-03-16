using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TitleExtrasScript : MonoBehaviour
{
	// Token: 0x06001EDE RID: 7902 RVA: 0x001B33E0 File Offset: 0x001B15E0
	private void Start()
	{
		base.transform.localPosition = new Vector3(1050f, base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x06001EDF RID: 7903 RVA: 0x001B3418 File Offset: 0x001B1618
	private void Update()
	{
		if (!this.Show)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 1050f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
			return;
		}
		base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
	}

	// Token: 0x04004006 RID: 16390
	public bool Show;
}
