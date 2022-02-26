using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x0600249D RID: 9373 RVA: 0x001FBF10 File Offset: 0x001FA110
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
