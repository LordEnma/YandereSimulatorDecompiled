using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002158 RID: 8536 RVA: 0x001EBA6A File Offset: 0x001E9C6A
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x001EBA74 File Offset: 0x001E9C74
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

	// Token: 0x0600215A RID: 8538 RVA: 0x001EBAEB File Offset: 0x001E9CEB
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x001EBAFA File Offset: 0x001E9CFA
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0400498A RID: 18826
	public Animator openandclosewindow1;

	// Token: 0x0400498B RID: 18827
	public bool open;

	// Token: 0x0400498C RID: 18828
	public Transform Player;
}
