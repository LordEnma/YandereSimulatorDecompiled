using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020FE RID: 8446 RVA: 0x001E63FD File Offset: 0x001E45FD
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x001E6408 File Offset: 0x001E4608
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

	// Token: 0x06002100 RID: 8448 RVA: 0x001E647F File Offset: 0x001E467F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002101 RID: 8449 RVA: 0x001E648E File Offset: 0x001E468E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048AA RID: 18602
	public Animator openandclose1;

	// Token: 0x040048AB RID: 18603
	public bool open;

	// Token: 0x040048AC RID: 18604
	public Transform Player;
}
