using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019AC RID: 6572 RVA: 0x00106324 File Offset: 0x00104524
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

	// Token: 0x04002935 RID: 10549
	public AdviceWindowScript AdviceWindow;
}
