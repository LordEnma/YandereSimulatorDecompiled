using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002121 RID: 8481 RVA: 0x001E8DE5 File Offset: 0x001E6FE5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x001E8DF0 File Offset: 0x001E6FF0
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

	// Token: 0x06002123 RID: 8483 RVA: 0x001E8E71 File Offset: 0x001E7071
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x001E8E80 File Offset: 0x001E7080
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004929 RID: 18729
	public Animator pull_01;

	// Token: 0x0400492A RID: 18730
	public bool open;

	// Token: 0x0400492B RID: 18731
	public Transform Player;
}
