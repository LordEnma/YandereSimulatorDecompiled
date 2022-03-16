using System;
using UnityEngine;

// Token: 0x02000362 RID: 866
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019A0 RID: 6560 RVA: 0x00105B78 File Offset: 0x00103D78
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

	// Token: 0x0400291F RID: 10527
	public AdviceWindowScript AdviceWindow;
}
