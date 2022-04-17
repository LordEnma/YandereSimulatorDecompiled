using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x06002136 RID: 8502 RVA: 0x001EB493 File Offset: 0x001E9693
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002137 RID: 8503 RVA: 0x001EB49C File Offset: 0x001E969C
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

	// Token: 0x06002138 RID: 8504 RVA: 0x001EB513 File Offset: 0x001E9713
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x001EB522 File Offset: 0x001E9722
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400496B RID: 18795
	public Animator openandclose;

	// Token: 0x0400496C RID: 18796
	public bool open;

	// Token: 0x0400496D RID: 18797
	public Transform Player;
}
