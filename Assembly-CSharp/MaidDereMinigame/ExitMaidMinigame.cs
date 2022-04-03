using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B5 RID: 1461
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024CB RID: 9419 RVA: 0x002000C0 File Offset: 0x001FE2C0
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
