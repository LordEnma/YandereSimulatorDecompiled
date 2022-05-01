using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x06002144 RID: 8516 RVA: 0x001EC9C5 File Offset: 0x001EABC5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002145 RID: 8517 RVA: 0x001EC9D0 File Offset: 0x001EABD0
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

	// Token: 0x06002146 RID: 8518 RVA: 0x001ECA47 File Offset: 0x001EAC47
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x001ECA56 File Offset: 0x001EAC56
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004984 RID: 18820
	public Animator openandclose1;

	// Token: 0x04004985 RID: 18821
	public bool open;

	// Token: 0x04004986 RID: 18822
	public Transform Player;
}
