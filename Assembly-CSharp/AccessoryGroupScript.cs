using System;
using UnityEngine;

// Token: 0x020000C1 RID: 193
public class AccessoryGroupScript : MonoBehaviour
{
	// Token: 0x0600099B RID: 2459 RVA: 0x0004CED4 File Offset: 0x0004B0D4
	public void SetPartsActive(bool active)
	{
		GameObject[] parts = this.Parts;
		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].SetActive(active);
		}
	}

	// Token: 0x04000853 RID: 2131
	public GameObject[] Parts;
}
