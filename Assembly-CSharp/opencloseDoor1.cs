using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x0600211C RID: 8476 RVA: 0x001E8D3D File Offset: 0x001E6F3D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x001E8D48 File Offset: 0x001E6F48
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

	// Token: 0x0600211E RID: 8478 RVA: 0x001E8DBF File Offset: 0x001E6FBF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x001E8DCE File Offset: 0x001E6FCE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004926 RID: 18726
	public Animator openandclose1;

	// Token: 0x04004927 RID: 18727
	public bool open;

	// Token: 0x04004928 RID: 18728
	public Transform Player;
}
