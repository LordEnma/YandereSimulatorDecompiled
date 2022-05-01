using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B7 RID: 1463
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024E3 RID: 9443 RVA: 0x002025EC File Offset: 0x002007EC
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
