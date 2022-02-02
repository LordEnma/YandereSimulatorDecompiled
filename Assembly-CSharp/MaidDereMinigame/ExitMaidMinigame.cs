using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002488 RID: 9352 RVA: 0x001FA960 File Offset: 0x001F8B60
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
