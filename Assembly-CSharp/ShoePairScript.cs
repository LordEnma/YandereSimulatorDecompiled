using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CAC RID: 7340 RVA: 0x001502F3 File Offset: 0x0014E4F3
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CAD RID: 7341 RVA: 0x00150318 File Offset: 0x0014E518
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

	// Token: 0x04003328 RID: 13096
	public PoliceScript Police;

	// Token: 0x04003329 RID: 13097
	public PromptScript Prompt;

	// Token: 0x0400332A RID: 13098
	public GameObject Note;
}
