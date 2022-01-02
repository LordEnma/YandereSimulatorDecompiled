using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020DD RID: 8413 RVA: 0x001E2FE5 File Offset: 0x001E11E5
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x001E2FF0 File Offset: 0x001E11F0
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

	// Token: 0x060020DF RID: 8415 RVA: 0x001E3071 File Offset: 0x001E1271
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020E0 RID: 8416 RVA: 0x001E3080 File Offset: 0x001E1280
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004865 RID: 18533
	public Animator pull_01;

	// Token: 0x04004866 RID: 18534
	public bool open;

	// Token: 0x04004867 RID: 18535
	public Transform Player;
}
