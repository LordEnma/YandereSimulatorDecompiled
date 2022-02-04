using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020EB RID: 8427 RVA: 0x001E5165 File Offset: 0x001E3365
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x001E5170 File Offset: 0x001E3370
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

	// Token: 0x060020ED RID: 8429 RVA: 0x001E51E7 File Offset: 0x001E33E7
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x001E51F6 File Offset: 0x001E33F6
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400488E RID: 18574
	public Animator openandclose1;

	// Token: 0x0400488F RID: 18575
	public bool open;

	// Token: 0x04004890 RID: 18576
	public Transform Player;
}
