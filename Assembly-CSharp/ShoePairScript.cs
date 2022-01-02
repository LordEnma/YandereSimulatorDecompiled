using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C70 RID: 7280 RVA: 0x0014B227 File Offset: 0x00149427
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x0014B24C File Offset: 0x0014944C
	private void Update()
	{
		if (this.Prompt.Yandere.Class.LanguageGrade + this.Prompt.Yandere.Class.LanguageBonus < 1)
		{
			this.Prompt.enabled = false;
		}
		else
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Police.SuicideNote = true;
			this.Note.SetActive(true);
			base.enabled = false;
		}
	}

	// Token: 0x04003294 RID: 12948
	public PoliceScript Police;

	// Token: 0x04003295 RID: 12949
	public PromptScript Prompt;

	// Token: 0x04003296 RID: 12950
	public GameObject Note;
}
