using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002140 RID: 8512 RVA: 0x001EB5E1 File Offset: 0x001E97E1
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002141 RID: 8513 RVA: 0x001EB5EC File Offset: 0x001E97EC
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

	// Token: 0x06002142 RID: 8514 RVA: 0x001EB66D File Offset: 0x001E986D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002143 RID: 8515 RVA: 0x001EB67C File Offset: 0x001E987C
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004971 RID: 18801
	public Animator pull_01;

	// Token: 0x04004972 RID: 18802
	public bool open;

	// Token: 0x04004973 RID: 18803
	public Transform Player;
}
