using System;
using UnityEngine;

// Token: 0x0200031D RID: 797
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001872 RID: 6258 RVA: 0x000EE454 File Offset: 0x000EC654
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001873 RID: 6259 RVA: 0x000EE4B4 File Offset: 0x000EC6B4
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024A9 RID: 9385
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024AA RID: 9386
	public float RotationSpeed;

	// Token: 0x040024AB RID: 9387
	public Material Unselectable;

	// Token: 0x040024AC RID: 9388
	public Renderer MyRenderer;

	// Token: 0x040024AD RID: 9389
	public int ID;
}
