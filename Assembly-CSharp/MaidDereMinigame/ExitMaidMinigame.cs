using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024EE RID: 9454 RVA: 0x00203D38 File Offset: 0x00201F38
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
