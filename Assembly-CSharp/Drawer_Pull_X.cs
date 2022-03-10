using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002109 RID: 8457 RVA: 0x001E6E7D File Offset: 0x001E507D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x0600210A RID: 8458 RVA: 0x001E6E88 File Offset: 0x001E5088
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

	// Token: 0x0600210B RID: 8459 RVA: 0x001E6F09 File Offset: 0x001E5109
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x001E6F18 File Offset: 0x001E5118
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040048CA RID: 18634
	public Animator pull_01;

	// Token: 0x040048CB RID: 18635
	public bool open;

	// Token: 0x040048CC RID: 18636
	public Transform Player;
}
