using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020E5 RID: 8421 RVA: 0x001E45AD File Offset: 0x001E27AD
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x001E45B8 File Offset: 0x001E27B8
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

	// Token: 0x060020E7 RID: 8423 RVA: 0x001E462F File Offset: 0x001E282F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x001E463E File Offset: 0x001E283E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400487D RID: 18557
	public Animator openandclose1;

	// Token: 0x0400487E RID: 18558
	public bool open;

	// Token: 0x0400487F RID: 18559
	public Transform Player;
}
