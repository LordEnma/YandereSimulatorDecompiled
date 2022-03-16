using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06001277 RID: 4727 RVA: 0x00090B32 File Offset: 0x0008ED32
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x00090B4C File Offset: 0x0008ED4C
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

	// Token: 0x040017C6 RID: 6086
	public YandereScript Yandere;

	// Token: 0x040017C7 RID: 6087
	public PromptScript Prompt;

	// Token: 0x040017C8 RID: 6088
	public GameObject FoldedUniform;

	// Token: 0x040017C9 RID: 6089
	public bool CanPickUp;
}
