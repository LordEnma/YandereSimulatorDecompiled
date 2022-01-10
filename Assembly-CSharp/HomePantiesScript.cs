using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x0600187F RID: 6271 RVA: 0x000EF230 File Offset: 0x000ED430
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001880 RID: 6272 RVA: 0x000EF290 File Offset: 0x000ED490
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024D1 RID: 9425
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024D2 RID: 9426
	public float RotationSpeed;

	// Token: 0x040024D3 RID: 9427
	public Material Unselectable;

	// Token: 0x040024D4 RID: 9428
	public Renderer MyRenderer;

	// Token: 0x040024D5 RID: 9429
	public int ID;
}
