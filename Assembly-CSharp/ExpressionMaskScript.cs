using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x0600147C RID: 5244 RVA: 0x000C7A7C File Offset: 0x000C5C7C
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

	// Token: 0x04001F9F RID: 8095
	public Renderer Mask;

	// Token: 0x04001FA0 RID: 8096
	public int ID;
}
