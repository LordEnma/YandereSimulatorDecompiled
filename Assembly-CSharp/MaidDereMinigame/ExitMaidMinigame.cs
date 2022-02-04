using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x0600248A RID: 9354 RVA: 0x001FAC78 File Offset: 0x001F8E78
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
