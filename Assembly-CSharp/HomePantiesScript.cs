using System;
using UnityEngine;

// Token: 0x02000321 RID: 801
public class HomePantiesScript : MonoBehaviour
{
	// Token: 0x06001892 RID: 6290 RVA: 0x000F0668 File Offset: 0x000EE868
	private void Start()
	{
		if (this.ID > 0 && !CollectibleGlobals.GetPantyPurchased(this.ID))
		{
			this.MyRenderer.material = this.Unselectable;
			this.MyRenderer.material.color = new Color(0f, 0f, 0f, 0.5f);
		}
	}

	// Token: 0x06001893 RID: 6291 RVA: 0x000F06C8 File Offset: 0x000EE8C8
	private void Update()
	{
		float y = (this.PantyChanger.Selected == this.ID) ? (base.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed) : 0f;
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
	}

	// Token: 0x04002506 RID: 9478
	public HomePantyChangerScript PantyChanger;

	// Token: 0x04002507 RID: 9479
	public float RotationSpeed;

	// Token: 0x04002508 RID: 9480
	public Material Unselectable;

	// Token: 0x04002509 RID: 9481
	public Renderer MyRenderer;

	// Token: 0x0400250A RID: 9482
	public int ID;
}
