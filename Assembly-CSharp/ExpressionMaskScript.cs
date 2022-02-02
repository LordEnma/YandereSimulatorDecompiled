using System;
using UnityEngine;

// Token: 0x020002BF RID: 703
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x06001477 RID: 5239 RVA: 0x000C7844 File Offset: 0x000C5A44
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

	// Token: 0x04001F97 RID: 8087
	public Renderer Mask;

	// Token: 0x04001F98 RID: 8088
	public int ID;
}
