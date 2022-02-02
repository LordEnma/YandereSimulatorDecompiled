using System;
using UnityEngine;

// Token: 0x02000236 RID: 566
public class CardboardBoxScript : MonoBehaviour
{
	// Token: 0x06001229 RID: 4649 RVA: 0x0008B0FC File Offset: 0x000892FC
	private void Start()
	{
		Physics.IgnoreCollision(this.Prompt.Yandere.GetComponent<Collider>(), base.GetComponent<Collider>());
	}

	// Token: 0x0600122A RID: 4650 RVA: 0x0008B11C File Offset: 0x0008931C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.MyCollider.enabled = false;
			this.Prompt.Circle[0].fillAmount = 1f;
			base.GetComponent<Rigidbody>().isKinematic = true;
			base.GetComponent<Rigidbody>().useGravity = false;
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.transform.parent = this.Prompt.Yandere.Hips;
			base.transform.localPosition = new Vector3(0f, -0.3f, 0.21f);
			base.transform.localEulerAngles = new Vector3(-13.333f, 0f, 0f);
		}
		if (base.transform.parent == this.Prompt.Yandere.Hips)
		{
			base.transform.localEulerAngles = Vector3.zero;
			if (this.Prompt.Yandere.Stance.Current != StanceType.Crawling)
			{
				base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
			}
			if (Input.GetButtonDown("RB"))
			{
				this.Prompt.MyCollider.enabled = true;
				base.GetComponent<Rigidbody>().isKinematic = false;
				base.GetComponent<Rigidbody>().useGravity = true;
				base.transform.parent = null;
				this.Prompt.enabled = true;
			}
		}
	}

	// Token: 0x040016CE RID: 5838
	public PromptScript Prompt;
}
