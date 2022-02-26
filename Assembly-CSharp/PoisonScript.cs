using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AC4 RID: 6852 RVA: 0x001228E4 File Offset: 0x00120AE4
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AC5 RID: 6853 RVA: 0x0012293C File Offset: 0x00120B3C
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

	// Token: 0x04002C9A RID: 11418
	public YandereScript Yandere;

	// Token: 0x04002C9B RID: 11419
	public PromptScript Prompt;

	// Token: 0x04002C9C RID: 11420
	public GameObject Bottle;
}
