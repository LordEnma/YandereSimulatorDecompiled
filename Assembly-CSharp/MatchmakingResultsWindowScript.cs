using System;
using UnityEngine;

// Token: 0x0200035F RID: 863
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x0600197F RID: 6527 RVA: 0x001035E0 File Offset: 0x001017E0
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

	// Token: 0x040028BB RID: 10427
	public AdviceWindowScript AdviceWindow;
}
