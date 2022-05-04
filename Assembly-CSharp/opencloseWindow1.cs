using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x06002162 RID: 8546 RVA: 0x001ECFF2 File Offset: 0x001EB1F2
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x001ECFFC File Offset: 0x001EB1FC
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

	// Token: 0x06002164 RID: 8548 RVA: 0x001ED073 File Offset: 0x001EB273
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x001ED082 File Offset: 0x001EB282
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049A0 RID: 18848
	public Animator openandclosewindow1;

	// Token: 0x040049A1 RID: 18849
	public bool open;

	// Token: 0x040049A2 RID: 18850
	public Transform Player;
}
