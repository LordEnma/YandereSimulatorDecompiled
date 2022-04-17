using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaDoubleFireballScript : MonoBehaviour
{
	// Token: 0x060020CA RID: 8394 RVA: 0x001E2D94 File Offset: 0x001E0F94
	private void Start()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x001E2E00 File Offset: 0x001E1000
	private void Update()
	{
		if (this.Timer > 1f && !this.SpawnedFirst)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			this.FirstLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
			this.FirstLavaball.transform.localScale = Vector3.zero;
			this.SpawnedFirst = true;
		}
		if (this.FirstLavaball != null)
		{
			this.FirstLavaball.transform.localScale = Vector3.Lerp(this.FirstLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.FirstPosition += ((this.FirstPosition == 0f) ? Time.deltaTime : (this.FirstPosition * this.Speed));
			this.FirstLavaball.transform.position = new Vector3(this.FirstLavaball.transform.position.x + this.FirstPosition * (float)this.Direction, this.FirstLavaball.transform.position.y, this.FirstLavaball.transform.position.z);
			this.FirstLavaball.transform.eulerAngles = new Vector3(this.FirstLavaball.transform.eulerAngles.x, this.FirstLavaball.transform.eulerAngles.y, this.FirstLavaball.transform.eulerAngles.z - this.FirstPosition * (float)this.Direction * 36f);
		}
		if (this.Timer > 2f && !this.SpawnedSecond)
		{
			this.SecondLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			this.SecondLavaball.transform.localScale = Vector3.zero;
			this.SpawnedSecond = true;
		}
		if (this.SecondLavaball != null)
		{
			this.SecondLavaball.transform.localScale = Vector3.Lerp(this.SecondLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.SecondPosition == 0f)
			{
				this.SecondPosition += Time.deltaTime;
			}
			else
			{
				this.SecondPosition += this.SecondPosition * this.Speed;
			}
			this.SecondLavaball.transform.position = new Vector3(this.SecondLavaball.transform.position.x + this.SecondPosition * (float)this.Direction, this.SecondLavaball.transform.position.y, this.SecondLavaball.transform.position.z);
			this.SecondLavaball.transform.eulerAngles = new Vector3(this.SecondLavaball.transform.eulerAngles.x, this.SecondLavaball.transform.eulerAngles.y, this.SecondLavaball.transform.eulerAngles.z - this.SecondPosition * (float)this.Direction * 36f);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 10f)
		{
			if (this.FirstLavaball != null)
			{
				UnityEngine.Object.Destroy(this.FirstLavaball);
			}
			if (this.SecondLavaball != null)
			{
				UnityEngine.Object.Destroy(this.SecondLavaball);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047F0 RID: 18416
	public GameObject Lavaball;

	// Token: 0x040047F1 RID: 18417
	public GameObject FirstLavaball;

	// Token: 0x040047F2 RID: 18418
	public GameObject SecondLavaball;

	// Token: 0x040047F3 RID: 18419
	public GameObject LightningEffect;

	// Token: 0x040047F4 RID: 18420
	public Transform Dracula;

	// Token: 0x040047F5 RID: 18421
	public bool SpawnedFirst;

	// Token: 0x040047F6 RID: 18422
	public bool SpawnedSecond;

	// Token: 0x040047F7 RID: 18423
	public float FirstPosition;

	// Token: 0x040047F8 RID: 18424
	public float SecondPosition;

	// Token: 0x040047F9 RID: 18425
	public int Direction;

	// Token: 0x040047FA RID: 18426
	public float Timer;

	// Token: 0x040047FB RID: 18427
	public float Speed;
}
