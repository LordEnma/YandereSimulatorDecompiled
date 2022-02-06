using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020EE RID: 8430 RVA: 0x001E5369 File Offset: 0x001E3569
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x001E5374 File Offset: 0x001E3574
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

	// Token: 0x060020F0 RID: 8432 RVA: 0x001E53EB File Offset: 0x001E35EB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E53FA File Offset: 0x001E35FA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004891 RID: 18577
	public Animator openandclose1;

	// Token: 0x04004892 RID: 18578
	public bool open;

	// Token: 0x04004893 RID: 18579
	public Transform Player;
}
