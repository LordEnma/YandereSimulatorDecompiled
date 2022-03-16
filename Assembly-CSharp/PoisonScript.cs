using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001ACF RID: 6863 RVA: 0x00123958 File Offset: 0x00121B58
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AD0 RID: 6864 RVA: 0x001239B0 File Offset: 0x00121BB0
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

	// Token: 0x04002CDC RID: 11484
	public YandereScript Yandere;

	// Token: 0x04002CDD RID: 11485
	public PromptScript Prompt;

	// Token: 0x04002CDE RID: 11486
	public GameObject Bottle;
}
