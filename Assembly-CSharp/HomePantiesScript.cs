using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001892 RID: 6290 RVA: 0x000F0330 File Offset: 0x000EE530
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001893 RID: 6291 RVA: 0x000F0390 File Offset: 0x000EE590
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024F2 RID: 9458
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024F3 RID: 9459
	public float RotationSpeed;

	// Token: 0x040024F4 RID: 9460
	public Material Unselectable;

	// Token: 0x040024F5 RID: 9461
	public Renderer MyRenderer;

	// Token: 0x040024F6 RID: 9462
	public int ID;
}
