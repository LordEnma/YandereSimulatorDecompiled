using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002484 RID: 9348 RVA: 0x001FA0C0 File Offset: 0x001F82C0
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
