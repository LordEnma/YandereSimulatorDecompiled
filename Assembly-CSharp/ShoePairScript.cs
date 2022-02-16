using System;
using UnityEngine;

// Token: 0x02000422 RID: 1058
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001C83 RID: 7299 RVA: 0x0014D677 File Offset: 0x0014B877
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x0014D69C File Offset: 0x0014B89C
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

	// Token: 0x040032AF RID: 12975
	public PoliceScript Police;

	// Token: 0x040032B0 RID: 12976
	public PromptScript Prompt;

	// Token: 0x040032B1 RID: 12977
	public GameObject Note;
}
