using System;
using System.Collections;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x060020F3 RID: 8435 RVA: 0x001E5411 File Offset: 0x001E3611
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E541C File Offset: 0x001E361C
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

	// Token: 0x060020F5 RID: 8437 RVA: 0x001E549D File Offset: 0x001E369D
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x001E54AC File Offset: 0x001E36AC
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x04004894 RID: 18580
	public Animator pull_01;

	// Token: 0x04004895 RID: 18581
	public bool open;

	// Token: 0x04004896 RID: 18582
	public Transform Player;
}
