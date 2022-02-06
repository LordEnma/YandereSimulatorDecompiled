using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AB4 RID: 6836 RVA: 0x00121B90 File Offset: 0x0011FD90
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AB5 RID: 6837 RVA: 0x00121BE8 File Offset: 0x0011FDE8
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

	// Token: 0x04002C84 RID: 11396
	public YandereScript Yandere;

	// Token: 0x04002C85 RID: 11397
	public PromptScript Prompt;

	// Token: 0x04002C86 RID: 11398
	public GameObject Bottle;
}
