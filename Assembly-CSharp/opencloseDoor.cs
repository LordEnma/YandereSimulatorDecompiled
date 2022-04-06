using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x0600212F RID: 8495 RVA: 0x001EAA37 File Offset: 0x001E8C37
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x001EAA40 File Offset: 0x001E8C40
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

	// Token: 0x06002131 RID: 8497 RVA: 0x001EAAB7 File Offset: 0x001E8CB7
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x001EAAC6 File Offset: 0x001E8CC6
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004959 RID: 18777
	public Animator openandclose;

	// Token: 0x0400495A RID: 18778
	public bool open;

	// Token: 0x0400495B RID: 18779
	public Transform Player;
}
