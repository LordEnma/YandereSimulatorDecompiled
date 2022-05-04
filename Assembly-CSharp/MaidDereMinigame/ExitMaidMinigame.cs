using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B7 RID: 1463
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024E4 RID: 9444 RVA: 0x002026E8 File Offset: 0x002008E8
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
