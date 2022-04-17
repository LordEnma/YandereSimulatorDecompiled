using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CB0 RID: 7344 RVA: 0x00150703 File Offset: 0x0014E903
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x00150728 File Offset: 0x0014E928
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

	// Token: 0x04003333 RID: 13107
	public PoliceScript Police;

	// Token: 0x04003334 RID: 13108
	public PromptScript Prompt;

	// Token: 0x04003335 RID: 13109
	public GameObject Note;
}
