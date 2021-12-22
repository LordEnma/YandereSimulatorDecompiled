using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002474 RID: 9332 RVA: 0x001F8460 File Offset: 0x001F6660
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
