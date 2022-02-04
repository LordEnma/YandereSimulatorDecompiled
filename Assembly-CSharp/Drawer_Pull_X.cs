using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020F0 RID: 8432 RVA: 0x001E520D File Offset: 0x001E340D
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E5218 File Offset: 0x001E3418
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

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E5299 File Offset: 0x001E3499
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E52A8 File Offset: 0x001E34A8
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004891 RID: 18577
	public Animator pull_01;

	// Token: 0x04004892 RID: 18578
	public bool open;

	// Token: 0x04004893 RID: 18579
	public Transform Player;
}
