using System;
using UnityEngine;

// Token: 0x02000320 RID: 800
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001889 RID: 6281 RVA: 0x000EFA4C File Offset: 0x000EDC4C
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x0600188A RID: 6282 RVA: 0x000EFAAC File Offset: 0x000EDCAC
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024E3 RID: 9443
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024E4 RID: 9444
	public float RotationSpeed;

	// Token: 0x040024E5 RID: 9445
	public Material Unselectable;

	// Token: 0x040024E6 RID: 9446
	public Renderer MyRenderer;

	// Token: 0x040024E7 RID: 9447
	public int ID;
}
