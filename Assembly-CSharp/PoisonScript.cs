using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AB1 RID: 6833 RVA: 0x001213C8 File Offset: 0x0011F5C8
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x00121420 File Offset: 0x0011F620
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

	// Token: 0x04002C77 RID: 11383
	public YandereScript Yandere;

	// Token: 0x04002C78 RID: 11384
	public PromptScript Prompt;

	// Token: 0x04002C79 RID: 11385
	public GameObject Bottle;
}
