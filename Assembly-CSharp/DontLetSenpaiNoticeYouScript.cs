using System;
using UnityEngine;

// Token: 0x020000CE RID: 206
public class DontLetSenpaiNoticeYouScript : MonoBehaviour
{
	// Token: 0x060009CE RID: 2510 RVA: 0x00051A9C File Offset: 0x0004FC9C
	private void Start()
	{
		while (this.ID < this.Letters.Length)
		{
			UILabel uilabel = this.Letters[this.ID];
			uilabel.transform.localScale = new Vector3(10f, 10f, 1f);
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0f);
			this.Origins[this.ID] = uilabel.transform.localPosition;
			this.ID++;
		}
		this.ID = 0;
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x00051B50 File Offset: 0x0004FD50
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			this.Proceed = true;
		}
		if (this.Proceed)
		{
			if (this.ID < this.Letters.Length)
			{
				UILabel uilabel = this.Letters[this.ID];
				uilabel.transform.localScale = Vector3.MoveTowards(uilabel.transform.localScale, Vector3.one, Time.deltaTime * 100f);
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, uilabel.color.a + Time.deltaTime * 10f);
				if (uilabel.transform.localScale == Vector3.one)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
					this.ID++;
				}
			}
			this.ShakeID = 0;
			while (this.ShakeID < this.Letters.Length)
			{
				UILabel uilabel2 = this.Letters[this.ShakeID];
				Vector3 vector = this.Origins[this.ShakeID];
				uilabel2.transform.localPosition = new Vector3(vector.x + UnityEngine.Random.Range(-5f, 5f), vector.y + UnityEngine.Random.Range(-5f, 5f), uilabel2.transform.localPosition.z);
				this.ShakeID++;
			}
		}
	}

	// Token: 0x04000A31 RID: 2609
	public UILabel[] Letters;

	// Token: 0x04000A32 RID: 2610
	public Vector3[] Origins;

	// Token: 0x04000A33 RID: 2611
	public AudioClip Slam;

	// Token: 0x04000A34 RID: 2612
	public bool Proceed;

	// Token: 0x04000A35 RID: 2613
	public int ShakeID;

	// Token: 0x04000A36 RID: 2614
	public int ID;
}
