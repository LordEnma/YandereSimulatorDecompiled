using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06001275 RID: 4725 RVA: 0x0009076A File Offset: 0x0008E96A
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x00090784 File Offset: 0x0008E984
	private void Update()
	{
		if (this.CanPickUp)
		{
			if (this.Yandere.Bloodiness == 0f)
			{
				this.CanPickUp = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Yandere.Bloodiness > 0f)
		{
			this.CanPickUp = true;
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Bloodiness = 0f;
			UnityEngine.Object.Instantiate<GameObject>(this.FoldedUniform, base.transform.position + Vector3.up, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040017C0 RID: 6080
	public YandereScript Yandere;

	// Token: 0x040017C1 RID: 6081
	public PromptScript Prompt;

	// Token: 0x040017C2 RID: 6082
	public GameObject FoldedUniform;

	// Token: 0x040017C3 RID: 6083
	public bool CanPickUp;
}
