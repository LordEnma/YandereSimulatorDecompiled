using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C9B RID: 7323 RVA: 0x0014F4CF File Offset: 0x0014D6CF
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x0014F4F4 File Offset: 0x0014D6F4
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

	// Token: 0x04003309 RID: 13065
	public PoliceScript Police;

	// Token: 0x0400330A RID: 13066
	public PromptScript Prompt;

	// Token: 0x0400330B RID: 13067
	public GameObject Note;
}
