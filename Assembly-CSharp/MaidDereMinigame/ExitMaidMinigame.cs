using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x0600248D RID: 9357 RVA: 0x001FAE7C File Offset: 0x001F907C
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
