using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024EF RID: 9455 RVA: 0x002042A0 File Offset: 0x002024A0
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
