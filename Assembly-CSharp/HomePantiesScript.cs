using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x060018A7 RID: 6311 RVA: 0x000F147C File Offset: 0x000EF67C
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x000F14DC File Offset: 0x000EF6DC
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002535 RID: 9525
	public HomePantyChangerScript PantyChanger;

	// Token: 0x04002536 RID: 9526
	public float RotationSpeed;

	// Token: 0x04002537 RID: 9527
	public Material Unselectable;

	// Token: 0x04002538 RID: 9528
	public Renderer MyRenderer;

	// Token: 0x04002539 RID: 9529
	public int ID;
}
