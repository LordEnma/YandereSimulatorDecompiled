using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class opencloseDoor1 : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E2F3D File Offset: 0x001E113D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E2F48 File Offset: 0x001E1148
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

	// Token: 0x060020DA RID: 8410 RVA: 0x001E2FBF File Offset: 0x001E11BF
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.openandclose1.Play("Opening 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x001E2FCE File Offset: 0x001E11CE
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.openandclose1.Play("Closing 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004862 RID: 18530
	public Animator openandclose1;

	// Token: 0x04004863 RID: 18531
	public bool open;

	// Token: 0x04004864 RID: 18532
	public Transform Player;
}
