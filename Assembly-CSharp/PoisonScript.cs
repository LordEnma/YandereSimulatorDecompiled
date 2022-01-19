using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AB1 RID: 6833 RVA: 0x00121530 File Offset: 0x0011F730
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x00121588 File Offset: 0x0011F788
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Inventory.ChemicalPoison = true;
			this.Yandere.Inventory.LethalPoisons++;
			this.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}

	// Token: 0x04002C7A RID: 11386
	public YandereScript Yandere;

	// Token: 0x04002C7B RID: 11387
	public PromptScript Prompt;

	// Token: 0x04002C7C RID: 11388
	public GameObject Bottle;
}
