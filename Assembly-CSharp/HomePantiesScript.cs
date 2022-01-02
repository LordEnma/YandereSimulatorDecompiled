using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x0600187B RID: 6267 RVA: 0x000EEEF8 File Offset: 0x000ED0F8
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x000EEF58 File Offset: 0x000ED158
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024CD RID: 9421
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024CE RID: 9422
	public float RotationSpeed;

	// Token: 0x040024CF RID: 9423
	public Material Unselectable;

	// Token: 0x040024D0 RID: 9424
	public Renderer MyRenderer;

	// Token: 0x040024D1 RID: 9425
	public int ID;
}
