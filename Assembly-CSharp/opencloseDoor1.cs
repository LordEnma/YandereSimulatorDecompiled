using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020D5 RID: 8405 RVA: 0x001E294D File Offset: 0x001E0B4D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E2958 File Offset: 0x001E0B58
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

	// Token: 0x060020D7 RID: 8407 RVA: 0x001E29CF File Offset: 0x001E0BCF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x001E29DE File Offset: 0x001E0BDE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004859 RID: 18521
	public Animator openandclose1;

	// Token: 0x0400485A RID: 18522
	public bool open;

	// Token: 0x0400485B RID: 18523
	public Transform Player;
}
