using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class opencloseDoor : MonoBehaviour
{
	// Token: 0x060020F9 RID: 8441 RVA: 0x001E6357 File Offset: 0x001E4557
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x001E6360 File Offset: 0x001E4560
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

	// Token: 0x060020FB RID: 8443 RVA: 0x001E63D7 File Offset: 0x001E45D7
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose.Play("Opening");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x001E63E6 File Offset: 0x001E45E6
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose.Play("Closing");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048A7 RID: 18599
	public Animator openandclose;

	// Token: 0x040048A8 RID: 18600
	public bool open;

	// Token: 0x040048A9 RID: 18601
	public Transform Player;
}
