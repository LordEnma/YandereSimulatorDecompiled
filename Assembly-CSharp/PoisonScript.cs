using System;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PoisonScript : MonoBehaviour
{
	// Token: 0x06001AA0 RID: 6816 RVA: 0x00120526 File Offset: 0x0011E726
	public void Start()
	{
		if (this.Yandere.Class.ChemistryGrade + this.Yandere.Class.ChemistryBonus < 1 && ClassGlobals.ChemistryGrade + ClassGlobals.ChemistryGrade < 1)
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001AA1 RID: 6817 RVA: 0x00120568 File Offset: 0x0011E768
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

	// Token: 0x04002C43 RID: 11331
	public YandereScript Yandere;

	// Token: 0x04002C44 RID: 11332
	public PromptScript Prompt;

	// Token: 0x04002C45 RID: 11333
	public GameObject Bottle;
}
