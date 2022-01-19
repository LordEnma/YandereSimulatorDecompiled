using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020E0 RID: 8416 RVA: 0x001E4507 File Offset: 0x001E2707
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x001E4510 File Offset: 0x001E2710
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

	// Token: 0x060020E2 RID: 8418 RVA: 0x001E4587 File Offset: 0x001E2787
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E4596 File Offset: 0x001E2796
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400487A RID: 18554
	public Animator openandclose;

	// Token: 0x0400487B RID: 18555
	public bool open;

	// Token: 0x0400487C RID: 18556
	public Transform Player;
}
