using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GreenRoomScript : MonoBehaviour
{
	// Token: 0x06001824 RID: 6180 RVA: 0x000E4BE9 File Offset: 0x000E2DE9
	private void Start()
	{
		this.QualityManager.Obscurance.enabled = false;
		this.UpdateColor();
	}

	// Token: 0x06001825 RID: 6181 RVA: 0x000E4C02 File Offset: 0x000E2E02
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.UpdateColor();
		}
	}

	// Token: 0x06001826 RID: 6182 RVA: 0x000E4C18 File Offset: 0x000E2E18
	private void UpdateColor()
	{
		this.ID++;
		if (this.ID > 7)
		{
			this.ID = 0;
		}
		this.Renderers[0].material.color = this.Colors[this.ID];
		this.Renderers[1].material.color = this.Colors[this.ID];
	}

	// Token: 0x04002306 RID: 8966
	public QualityManagerScript QualityManager;

	// Token: 0x04002307 RID: 8967
	public Color[] Colors;

	// Token: 0x04002308 RID: 8968
	public Renderer[] Renderers;

	// Token: 0x04002309 RID: 8969
	public int ID;
}
