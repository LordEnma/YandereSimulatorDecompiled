using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000508 RID: 1288
public class opencloseWindow1 : MonoBehaviour
{
	// Token: 0x0600216C RID: 8556 RVA: 0x001EE642 File Offset: 0x001EC842
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600216D RID: 8557 RVA: 0x001EE64C File Offset: 0x001EC84C
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

	// Token: 0x0600216E RID: 8558 RVA: 0x001EE6C3 File Offset: 0x001EC8C3
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the Window");
		this.openandclosewindow1.Play("Openingwindow 1");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x001EE6D2 File Offset: 0x001EC8D2
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the Window");
		this.openandclosewindow1.Play("Closingwindow 1");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049C7 RID: 18887
	public Animator openandclosewindow1;

	// Token: 0x040049C8 RID: 18888
	public bool open;

	// Token: 0x040049C9 RID: 18889
	public Transform Player;
}
