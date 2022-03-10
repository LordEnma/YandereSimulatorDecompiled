using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001998 RID: 6552 RVA: 0x00105200 File Offset: 0x00103400
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

	// Token: 0x040028FD RID: 10493
	public AdviceWindowScript AdviceWindow;
}
