using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020E9 RID: 8425 RVA: 0x001E4E4D File Offset: 0x001E304D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x001E4E58 File Offset: 0x001E3058
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

	// Token: 0x060020EB RID: 8427 RVA: 0x001E4ECF File Offset: 0x001E30CF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x001E4EDE File Offset: 0x001E30DE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004888 RID: 18568
	public Animator openandclose1;

	// Token: 0x04004889 RID: 18569
	public bool open;

	// Token: 0x0400488A RID: 18570
	public Transform Player;
}
