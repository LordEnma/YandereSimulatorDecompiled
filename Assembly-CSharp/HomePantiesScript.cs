using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x060018A3 RID: 6307 RVA: 0x000F11E8 File Offset: 0x000EF3E8
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x000F1248 File Offset: 0x000EF448
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x0400252D RID: 9517
	public HomePantyChangerScript PantyChanger;

	// Token: 0x0400252E RID: 9518
	public float RotationSpeed;

	// Token: 0x0400252F RID: 9519
	public Material Unselectable;

	// Token: 0x04002530 RID: 9520
	public Renderer MyRenderer;

	// Token: 0x04002531 RID: 9521
	public int ID;
}
