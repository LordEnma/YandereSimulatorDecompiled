using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C6E RID: 7278 RVA: 0x0014AE1F File Offset: 0x0014901F
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x0014AE44 File Offset: 0x00149044
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

	// Token: 0x0400328D RID: 12941
	public PoliceScript Police;

	// Token: 0x0400328E RID: 12942
	public PromptScript Prompt;

	// Token: 0x0400328F RID: 12943
	public GameObject Note;
}
