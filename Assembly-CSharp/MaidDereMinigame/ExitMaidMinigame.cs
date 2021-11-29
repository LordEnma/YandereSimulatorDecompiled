using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002463 RID: 9315 RVA: 0x001F6D2C File Offset: 0x001F4F2C
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
