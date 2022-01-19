using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020EA RID: 8426 RVA: 0x001E4655 File Offset: 0x001E2855
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x001E4660 File Offset: 0x001E2860
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

	// Token: 0x060020EC RID: 8428 RVA: 0x001E46E1 File Offset: 0x001E28E1
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020ED RID: 8429 RVA: 0x001E46F0 File Offset: 0x001E28F0
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004880 RID: 18560
	public Animator pull_01;

	// Token: 0x04004881 RID: 18561
	public bool open;

	// Token: 0x04004882 RID: 18562
	public Transform Player;
}
