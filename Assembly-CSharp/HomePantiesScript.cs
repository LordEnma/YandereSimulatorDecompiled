using System;
using UnityEngine;

// Token: 0x02000324 RID: 804
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x060018B0 RID: 6320 RVA: 0x000F1DC8 File Offset: 0x000EFFC8
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x000F1E28 File Offset: 0x000F0028
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x0400254A RID: 9546
	public HomePantyChangerScript PantyChanger;

	// Token: 0x0400254B RID: 9547
	public float RotationSpeed;

	// Token: 0x0400254C RID: 9548
	public Material Unselectable;

	// Token: 0x0400254D RID: 9549
	public Renderer MyRenderer;

	// Token: 0x0400254E RID: 9550
	public int ID;
}
