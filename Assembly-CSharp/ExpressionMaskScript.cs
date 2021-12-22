using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x06001472 RID: 5234 RVA: 0x000C7044 File Offset: 0x000C5244
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

	// Token: 0x04001F89 RID: 8073
	public Renderer Mask;

	// Token: 0x04001F8A RID: 8074
	public int ID;
}
