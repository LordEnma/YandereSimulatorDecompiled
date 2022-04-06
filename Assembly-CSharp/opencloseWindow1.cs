using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000506 RID: 1286
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002151 RID: 8529 RVA: 0x001EB00E File Offset: 0x001E920E
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x001EB018 File Offset: 0x001E9218
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

	// Token: 0x06002153 RID: 8531 RVA: 0x001EB08F File Offset: 0x001E928F
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002154 RID: 8532 RVA: 0x001EB09E File Offset: 0x001E929E
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004978 RID: 18808
	public Animator openandclosewindow1;

	// Token: 0x04004979 RID: 18809
	public bool open;

	// Token: 0x0400497A RID: 18810
	public Transform Player;
}
