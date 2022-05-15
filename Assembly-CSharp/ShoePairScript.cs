using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CBD RID: 7357 RVA: 0x00151BBF File Offset: 0x0014FDBF
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x00151BE4 File Offset: 0x0014FDE4
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

	// Token: 0x04003357 RID: 13143
	public PoliceScript Police;

	// Token: 0x04003358 RID: 13144
	public PromptScript Prompt;

	// Token: 0x04003359 RID: 13145
	public GameObject Note;
}
