using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B6 RID: 1462
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024DA RID: 9434 RVA: 0x0020104C File Offset: 0x001FF24C
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
