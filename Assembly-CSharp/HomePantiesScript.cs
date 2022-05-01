using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x060018AB RID: 6315 RVA: 0x000F1980 File Offset: 0x000EFB80
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x000F19E0 File Offset: 0x000EFBE0
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x0400253E RID: 9534
	public HomePantyChangerScript PantyChanger;

	// Token: 0x0400253F RID: 9535
	public float RotationSpeed;

	// Token: 0x04002540 RID: 9536
	public Material Unselectable;

	// Token: 0x04002541 RID: 9537
	public Renderer MyRenderer;

	// Token: 0x04002542 RID: 9538
	public int ID;
}
