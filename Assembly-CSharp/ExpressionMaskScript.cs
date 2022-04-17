using System;
using UnityEngine;

// Token: 0x020002C2 RID: 706
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x0600148F RID: 5263 RVA: 0x000C8D04 File Offset: 0x000C6F04
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			if (this.ID < 3)
			{
				this.ID++;
			}
			else
			{
				this.ID = 0;
			}
			switch (this.ID)
			{
			case 0:
				this.Mask.material.mainTextureOffset = Vector2.zero;
				return;
			case 1:
				this.Mask.material.mainTextureOffset = new Vector2(0f, 0.5f);
				return;
			case 2:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0f);
				return;
			case 3:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x04001FCE RID: 8142
	public Renderer Mask;

	// Token: 0x04001FCF RID: 8143
	public int ID;
}
