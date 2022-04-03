using System;
using UnityEngine;

// Token: 0x02000363 RID: 867
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019A6 RID: 6566 RVA: 0x00106224 File Offset: 0x00104424
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

	// Token: 0x04002932 RID: 10546
	public AdviceWindowScript AdviceWindow;
}
