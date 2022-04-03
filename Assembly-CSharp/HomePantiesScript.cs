using System;
using UnityEngine;

// Token: 0x02000322 RID: 802
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x0600189D RID: 6301 RVA: 0x000F10E8 File Offset: 0x000EF2E8
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x000F1148 File Offset: 0x000EF348
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x0400252A RID: 9514
	public HomePantyChangerScript PantyChanger;

	// Token: 0x0400252B RID: 9515
	public float RotationSpeed;

	// Token: 0x0400252C RID: 9516
	public Material Unselectable;

	// Token: 0x0400252D RID: 9517
	public Renderer MyRenderer;

	// Token: 0x0400252E RID: 9518
	public int ID;
}
