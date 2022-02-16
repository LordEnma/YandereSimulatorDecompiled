using System;
using UnityEngine;

// Token: 0x02000361 RID: 865
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x0600198F RID: 6543 RVA: 0x00104568 File Offset: 0x00102768
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

	// Token: 0x040028D8 RID: 10456
	public AdviceWindowScript AdviceWindow;
}
