using System;
using UnityEngine;

// Token: 0x020003A8 RID: 936
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AAA RID: 6826 RVA: 0x00121080 File Offset: 0x0011F280
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
			return;
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001AAB RID: 6827 RVA: 0x001210D8 File Offset: 0x0011F2D8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Inventory.ChemicalPoison = true;
			this.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
			UnityEngine.Object.Destroy(this.Bottle);
		}
	}

	// Token: 0x04002C71 RID: 11377
	public YandereScript Yandere;

	// Token: 0x04002C72 RID: 11378
	public PromptScript Prompt;

	// Token: 0x04002C73 RID: 11379
	public GameObject Bottle;
}
