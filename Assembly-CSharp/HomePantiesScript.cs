using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001880 RID: 6272 RVA: 0x000EF730 File Offset: 0x000ED930
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001881 RID: 6273 RVA: 0x000EF790 File Offset: 0x000ED990
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024D9 RID: 9433
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024DA RID: 9434
	public float RotationSpeed;

	// Token: 0x040024DB RID: 9435
	public Material Unselectable;

	// Token: 0x040024DC RID: 9436
	public Renderer MyRenderer;

	// Token: 0x040024DD RID: 9437
	public int ID;
}
