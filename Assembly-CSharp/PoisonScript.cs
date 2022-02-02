using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AB2 RID: 6834 RVA: 0x00121974 File Offset: 0x0011FB74
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AB3 RID: 6835 RVA: 0x001219CC File Offset: 0x0011FBCC
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

	// Token: 0x04002C80 RID: 11392
	public YandereScript Yandere;

	// Token: 0x04002C81 RID: 11393
	public PromptScript Prompt;

	// Token: 0x04002C82 RID: 11394
	public GameObject Bottle;
}
