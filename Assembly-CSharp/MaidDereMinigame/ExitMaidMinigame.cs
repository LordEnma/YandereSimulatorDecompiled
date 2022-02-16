using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002494 RID: 9364 RVA: 0x001FB330 File Offset: 0x001F9530
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
