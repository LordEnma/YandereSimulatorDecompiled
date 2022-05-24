using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class Drawer_Pull_X : MonoBehaviour
{
	// Token: 0x06002155 RID: 8533 RVA: 0x001EE721 File Offset: 0x001EC921
	private void Start()
	{
		this.open = false;
	}

	// Token: 0x06002156 RID: 8534 RVA: 0x001EE72C File Offset: 0x001EC92C
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

	// Token: 0x06002157 RID: 8535 RVA: 0x001EE7AD File Offset: 0x001EC9AD
	private IEnumerator opening()
	{
		MonoBehaviour.print("you are opening the door");
		this.pull_01.Play("openpull_01");
		this.open = true;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x06002158 RID: 8536 RVA: 0x001EE7BC File Offset: 0x001EC9BC
	private IEnumerator closing()
	{
		MonoBehaviour.print("you are closing the door");
		this.pull_01.Play("closepush_01");
		this.open = false;
		yield return new WaitForSeconds(0.5f);
		yield break;
	}

	// Token: 0x040049B7 RID: 18871
	public Animator pull_01;

	// Token: 0x040049B8 RID: 18872
	public bool open;

	// Token: 0x040049B9 RID: 18873
	public Transform Player;
}
