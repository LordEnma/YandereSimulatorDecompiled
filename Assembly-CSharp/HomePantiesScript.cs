using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001897 RID: 6295 RVA: 0x000F0B28 File Offset: 0x000EED28
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001898 RID: 6296 RVA: 0x000F0B88 File Offset: 0x000EED88
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002517 RID: 9495
	public HomePantyChangerScript PantyChanger;

	// Token: 0x04002518 RID: 9496
	public float RotationSpeed;

	// Token: 0x04002519 RID: 9497
	public Material Unselectable;

	// Token: 0x0400251A RID: 9498
	public Renderer MyRenderer;

	// Token: 0x0400251B RID: 9499
	public int ID;
}
