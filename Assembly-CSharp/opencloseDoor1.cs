using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E581D File Offset: 0x001E3A1D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E5828 File Offset: 0x001E3A28
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

	// Token: 0x060020F7 RID: 8439 RVA: 0x001E589F File Offset: 0x001E3A9F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x001E58AE File Offset: 0x001E3AAE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400489A RID: 18586
	public Animator openandclose1;

	// Token: 0x0400489B RID: 18587
	public bool open;

	// Token: 0x0400489C RID: 18588
	public Transform Player;
}
