﻿using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001988 RID: 6536 RVA: 0x001043C4 File Offset: 0x001025C4
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

	// Token: 0x040028D2 RID: 10450
	public AdviceWindowScript AdviceWindow;
}
