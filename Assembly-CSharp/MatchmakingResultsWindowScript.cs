using System;
using UnityEngine;

// Token: 0x02000365 RID: 869
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019BB RID: 6587 RVA: 0x001074C4 File Offset: 0x001056C4
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

	// Token: 0x0400295E RID: 10590
	public AdviceWindowScript AdviceWindow;
}
