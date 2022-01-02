using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001981 RID: 6529 RVA: 0x001038BC File Offset: 0x00101ABC
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			this.AdviceWindow.HUDElement[1].SetActive(true);
			this.AdviceWindow.HUDElement[2].SetActive(true);
			this.AdviceWindow.HUDElement[3].SetActive(true);
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	// Token: 0x040028BF RID: 10431
	public AdviceWindowScript AdviceWindow;
}
