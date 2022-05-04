using System;
using UnityEngine;

// Token: 0x02000429 RID: 1065
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CB7 RID: 7351 RVA: 0x00150F0B File Offset: 0x0014F10B
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CB8 RID: 7352 RVA: 0x00150F30 File Offset: 0x0014F130
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

	// Token: 0x04003342 RID: 13122
	public PoliceScript Police;

	// Token: 0x04003343 RID: 13123
	public PromptScript Prompt;

	// Token: 0x04003344 RID: 13124
	public GameObject Note;
}
