using System;
using UnityEngine;

// Token: 0x0200024E RID: 590
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06001275 RID: 4725 RVA: 0x00090622 File Offset: 0x0008E822
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x0009063C File Offset: 0x0008E83C
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

	// Token: 0x040017B7 RID: 6071
	public YandereScript Yandere;

	// Token: 0x040017B8 RID: 6072
	public PromptScript Prompt;

	// Token: 0x040017B9 RID: 6073
	public GameObject FoldedUniform;

	// Token: 0x040017BA RID: 6074
	public bool CanPickUp;
}
