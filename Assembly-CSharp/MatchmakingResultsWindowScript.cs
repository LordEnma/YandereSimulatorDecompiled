using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019B0 RID: 6576 RVA: 0x001065B8 File Offset: 0x001047B8
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

	// Token: 0x0400293D RID: 10557
	public AdviceWindowScript AdviceWindow;
}
