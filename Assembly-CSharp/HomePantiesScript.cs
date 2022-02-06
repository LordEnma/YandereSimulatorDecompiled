using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001882 RID: 6274 RVA: 0x000EF8D4 File Offset: 0x000EDAD4
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001883 RID: 6275 RVA: 0x000EF934 File Offset: 0x000EDB34
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024DD RID: 9437
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024DE RID: 9438
	public float RotationSpeed;

	// Token: 0x040024DF RID: 9439
	public Material Unselectable;

	// Token: 0x040024E0 RID: 9440
	public Renderer MyRenderer;

	// Token: 0x040024E1 RID: 9441
	public int ID;
}
