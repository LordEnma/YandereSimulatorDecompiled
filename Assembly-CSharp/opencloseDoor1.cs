using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020E3 RID: 8419 RVA: 0x001E38DD File Offset: 0x001E1ADD
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E38E8 File Offset: 0x001E1AE8
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

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E395F File Offset: 0x001E1B5F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x001E396E File Offset: 0x001E1B6E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004876 RID: 18550
	public Animator openandclose1;

	// Token: 0x04004877 RID: 18551
	public bool open;

	// Token: 0x04004878 RID: 18552
	public Transform Player;
}
