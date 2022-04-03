using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x0600212C RID: 8492 RVA: 0x001EA5AD File Offset: 0x001E87AD
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x001EA5B8 File Offset: 0x001E87B8
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

	// Token: 0x0600212E RID: 8494 RVA: 0x001EA62F File Offset: 0x001E882F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001EA63E File Offset: 0x001E883E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004958 RID: 18776
	public Animator openandclose1;

	// Token: 0x04004959 RID: 18777
	public bool open;

	// Token: 0x0400495A RID: 18778
	public Transform Player;
}
