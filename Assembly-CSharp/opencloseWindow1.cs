using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002139 RID: 8505 RVA: 0x001E926E File Offset: 0x001E746E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x001E9278 File Offset: 0x001E7478
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

	// Token: 0x0600213B RID: 8507 RVA: 0x001E92EF File Offset: 0x001E74EF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x001E92FE File Offset: 0x001E74FE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004942 RID: 18754
	public Animator openandclosewindow1;

	// Token: 0x04004943 RID: 18755
	public bool open;

	// Token: 0x04004944 RID: 18756
	public Transform Player;
}
