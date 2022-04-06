using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B6 RID: 1462
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024D3 RID: 9427 RVA: 0x002005F0 File Offset: 0x001FE7F0
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
