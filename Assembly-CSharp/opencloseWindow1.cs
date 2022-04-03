using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002149 RID: 8521 RVA: 0x001EAADE File Offset: 0x001E8CDE
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x001EAAE8 File Offset: 0x001E8CE8
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

	// Token: 0x0600214B RID: 8523 RVA: 0x001EAB5F File Offset: 0x001E8D5F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x001EAB6E File Offset: 0x001E8D6E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004974 RID: 18804
	public Animator openandclosewindow1;

	// Token: 0x04004975 RID: 18805
	public bool open;

	// Token: 0x04004976 RID: 18806
	public Transform Player;
}
