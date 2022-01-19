using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002102 RID: 8450 RVA: 0x001E4ADE File Offset: 0x001E2CDE
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x001E4AE8 File Offset: 0x001E2CE8
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 15f)
		{
			if (!this.open)
			{
				if (Input.GetMouseButtonDown(0))
				{
					base.StartCoroutine(this.opening());
					return;
				}
			}
			else if (this.open && Input.GetMouseButtonDown(0))
			{
				base.StartCoroutine(this.closing());
			}
		}
	}

	// Token: 0x06002104 RID: 8452 RVA: 0x001E4B5F File Offset: 0x001E2D5F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002105 RID: 8453 RVA: 0x001E4B6E File Offset: 0x001E2D6E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004899 RID: 18585
	public Animator openandclosewindow1;

	// Token: 0x0400489A RID: 18586
	public bool open;

	// Token: 0x0400489B RID: 18587
	public Transform Player;
}
