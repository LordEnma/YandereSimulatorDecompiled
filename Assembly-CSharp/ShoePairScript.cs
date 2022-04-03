using System;
using UnityEngine;

// Token: 0x02000427 RID: 1063
public class ShoePairScript : MonoBehaviour
{
	// Token: 0x06001CA5 RID: 7333 RVA: 0x0014FFF3 File Offset: 0x0014E1F3
	private void Start()
	{
		this.Police = GameObject.Find("Police").GetComponent<PoliceScript>();
		this.Note.SetActive(false);
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x00150018 File Offset: 0x0014E218
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

	// Token: 0x04003325 RID: 13093
	public PoliceScript Police;

	// Token: 0x04003326 RID: 13094
	public PromptScript Prompt;

	// Token: 0x04003327 RID: 13095
	public GameObject Note;
}
