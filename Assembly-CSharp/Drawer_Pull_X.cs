using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000503 RID: 1283
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x0600214A RID: 8522 RVA: 0x001ECB69 File Offset: 0x001EAD69
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x001ECB74 File Offset: 0x001EAD74
	private void OnMouseOver()
	{
		if (this.Player && Vector3.Distance(this.Player.position, base.transform.position) < 10f)
		{
			MonoBehaviour.print("object name");
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

	// Token: 0x0600214C RID: 8524 RVA: 0x001ECBF5 File Offset: 0x001EADF5
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x001ECC04 File Offset: 0x001EAE04
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004987 RID: 18823
	public Animator pull_01;

	// Token: 0x04004988 RID: 18824
	public bool open;

	// Token: 0x04004989 RID: 18825
	public Transform Player;
}
