using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001978 RID: 6520 RVA: 0x00102D84 File Offset: 0x00100F84
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

	// Token: 0x04002896 RID: 10390
	public AdviceWindowScript AdviceWindow;
}
