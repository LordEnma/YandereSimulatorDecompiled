using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001985 RID: 6533 RVA: 0x00103DC4 File Offset: 0x00101FC4
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

	// Token: 0x040028C8 RID: 10440
	public AdviceWindowScript AdviceWindow;
}
