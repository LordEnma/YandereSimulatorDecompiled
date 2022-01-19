using System;
using UnityEngine;

// Token: 0x0200031F RID: 799
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x0600187F RID: 6271 RVA: 0x000EF31C File Offset: 0x000ED51C
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001880 RID: 6272 RVA: 0x000EF37C File Offset: 0x000ED57C
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x040024D4 RID: 9428
	public HomePantyChangerScript PantyChanger;

	// Token: 0x040024D5 RID: 9429
	public float RotationSpeed;

	// Token: 0x040024D6 RID: 9430
	public Material Unselectable;

	// Token: 0x040024D7 RID: 9431
	public Renderer MyRenderer;

	// Token: 0x040024D8 RID: 9432
	public int ID;
}
