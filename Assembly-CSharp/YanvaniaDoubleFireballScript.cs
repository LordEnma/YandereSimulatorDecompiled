using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaDoubleFireballScript : MonoBehaviour
{
	// Token: 0x06002055 RID: 8277 RVA: 0x001D8AA8 File Offset: 0x001D6CA8
	private void Start()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x06002056 RID: 8278 RVA: 0x001D8B14 File Offset: 0x001D6D14
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

	// Token: 0x0400469D RID: 18077
	public GameObject Lavaball;

	// Token: 0x0400469E RID: 18078
	public GameObject FirstLavaball;

	// Token: 0x0400469F RID: 18079
	public GameObject SecondLavaball;

	// Token: 0x040046A0 RID: 18080
	public GameObject LightningEffect;

	// Token: 0x040046A1 RID: 18081
	public Transform Dracula;

	// Token: 0x040046A2 RID: 18082
	public bool SpawnedFirst;

	// Token: 0x040046A3 RID: 18083
	public bool SpawnedSecond;

	// Token: 0x040046A4 RID: 18084
	public float FirstPosition;

	// Token: 0x040046A5 RID: 18085
	public float SecondPosition;

	// Token: 0x040046A6 RID: 18086
	public int Direction;

	// Token: 0x040046A7 RID: 18087
	public float Timer;

	// Token: 0x040046A8 RID: 18088
	public float Speed;
}
