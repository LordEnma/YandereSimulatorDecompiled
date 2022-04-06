using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x06002134 RID: 8500 RVA: 0x001EAADD File Offset: 0x001E8CDD
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x001EAAE8 File Offset: 0x001E8CE8
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

	// Token: 0x06002136 RID: 8502 RVA: 0x001EAB5F File Offset: 0x001E8D5F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x001EAB6E File Offset: 0x001E8D6E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400495C RID: 18780
	public Animator openandclose1;

	// Token: 0x0400495D RID: 18781
	public bool open;

	// Token: 0x0400495E RID: 18782
	public Transform Player;
}
