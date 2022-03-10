using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class ExitMaidMinigame : MonoBehaviour
	{
		// Token: 0x060024A3 RID: 9379 RVA: 0x001FC8E8 File Offset: 0x001FAAE8
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene(true);
			}
		}
	}
}
