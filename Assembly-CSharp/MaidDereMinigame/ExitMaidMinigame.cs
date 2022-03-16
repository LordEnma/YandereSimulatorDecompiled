using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B0 RID: 1456
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024BB RID: 9403 RVA: 0x001FE850 File Offset: 0x001FCA50
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
