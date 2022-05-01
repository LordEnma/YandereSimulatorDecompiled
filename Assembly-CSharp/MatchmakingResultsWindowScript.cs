using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x060019B4 RID: 6580 RVA: 0x00106AB8 File Offset: 0x00104CB8
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

	// Token: 0x04002946 RID: 10566
	public AdviceWindowScript AdviceWindow;
}
