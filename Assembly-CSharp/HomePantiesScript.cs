using System;
using UnityEngine;

// Token: 0x0200031E RID: 798
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001879 RID: 6265 RVA: 0x000EEC44 File Offset: 0x000ECE44
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x0600187A RID: 6266 RVA: 0x000EECA4 File Offset: 0x000ECEA4
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024C9 RID: 9417
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024CA RID: 9418
	public float RotationSpeed;

	// Token: 0x040024CB RID: 9419
	public Material Unselectable;

	// Token: 0x040024CC RID: 9420
	public Renderer MyRenderer;

	// Token: 0x040024CD RID: 9421
	public int ID;
}
