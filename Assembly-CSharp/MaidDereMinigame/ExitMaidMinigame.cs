using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x06002477 RID: 9335 RVA: 0x001F8A50 File Offset: 0x001F6C50
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
