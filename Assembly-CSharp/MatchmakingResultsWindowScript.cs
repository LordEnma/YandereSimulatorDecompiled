using System;
using UnityEngine;

// Token: 0x02000365 RID: 869
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019BA RID: 6586 RVA: 0x001072C0 File Offset: 0x001054C0
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

	// Token: 0x04002957 RID: 10583
	public AdviceWindowScript AdviceWindow;
}
