using System;
using UnityEngine;

// Token: 0x02000423 RID: 1059
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C8C RID: 7308 RVA: 0x0014E0EF File Offset: 0x0014C2EF
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C8D RID: 7309 RVA: 0x0014E114 File Offset: 0x0014C314
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

	// Token: 0x040032BF RID: 12991
	public PoliceScript Police;

	// Token: 0x040032C0 RID: 12992
	public PromptScript Prompt;

	// Token: 0x040032C1 RID: 12993
	public GameObject Note;
}
