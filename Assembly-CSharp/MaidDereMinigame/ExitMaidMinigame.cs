using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002482 RID: 9346 RVA: 0x001F93F0 File Offset: 0x001F75F0
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
