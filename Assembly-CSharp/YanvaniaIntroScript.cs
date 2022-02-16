using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaIntroScript : MonoBehaviour
{
	// Token: 0x06002090 RID: 8336 RVA: 0x001DE314 File Offset: 0x001DC514
	private void Start()
	{
		this.BlackRight.gameObject.SetActive(true);
		this.BlackLeft.gameObject.SetActive(true);
		this.FinalStage.gameObject.SetActive(true);
		this.Heartbreak.gameObject.SetActive(true);
		this.Triangle.gameObject.SetActive(true);
		this.Triangle.transform.localScale = Vector3.zero;
		this.Heartbreak.transform.localPosition = new Vector3(1300f, this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
		this.FinalStage.transform.localPosition = new Vector3(-1300f, this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
	}

	// Token: 0x06002091 RID: 8337 RVA: 0x001DE414 File Offset: 0x001DC614
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 1f && this.Timer < 3f)
		{
			this.Yanmont.Character.transform.localScale = new Vector3(-1f, this.Yanmont.Character.transform.localScale.y, this.Yanmont.Character.transform.localScale.z);
			if (!this.Jukebox.activeInHierarchy)
			{
				this.Jukebox.SetActive(true);
			}
			this.Triangle.transform.localScale = Vector3.Lerp(this.Triangle.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Heartbreak.transform.localPosition = new Vector3(Mathf.Lerp(this.Heartbreak.transform.localPosition.x, 0f, Time.deltaTime * 10f), this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
			this.FinalStage.transform.localPosition = new Vector3(Mathf.Lerp(this.FinalStage.transform.localPosition.x, 0f, Time.deltaTime * 10f), this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
		}
		else if (this.Timer > 3f)
		{
			if (!this.Jukebox.activeInHierarchy)
			{
				this.Jukebox.SetActive(true);
			}
			this.Triangle.transform.localEulerAngles = new Vector3(this.Triangle.transform.localEulerAngles.x, this.Triangle.transform.localEulerAngles.y, this.Triangle.transform.localEulerAngles.z + 36f * Time.deltaTime);
			this.Triangle.color = new Color(this.Triangle.color.r, this.Triangle.color.g, this.Triangle.color.b, this.Triangle.color.a - Time.deltaTime);
			this.Heartbreak.color = new Color(this.Heartbreak.color.r, this.Heartbreak.color.g, this.Heartbreak.color.b, this.Heartbreak.color.a - Time.deltaTime);
			this.FinalStage.color = new Color(this.FinalStage.color.r, this.FinalStage.color.g, this.FinalStage.color.b, this.FinalStage.color.a - Time.deltaTime);
		}
		if (this.Timer > 4f)
		{
			this.Finish();
		}
		if (this.Timer > this.LeaveTime)
		{
			this.Position += ((this.Position == 0f) ? Time.deltaTime : (this.Position * 0.1f));
			if (this.BlackLeft.localPosition.x > -2100f)
			{
				this.BlackRight.localPosition = new Vector3(this.BlackRight.localPosition.x + this.Position, this.BlackRight.localPosition.y, this.BlackRight.localPosition.z);
				this.BlackLeft.localPosition = new Vector3(this.BlackLeft.localPosition.x - this.Position, this.BlackLeft.localPosition.y, this.BlackLeft.localPosition.z);
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			this.Finish();
		}
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x001DE86D File Offset: 0x001DCA6D
	private void Finish()
	{
		if (!this.Jukebox.activeInHierarchy)
		{
			this.Jukebox.SetActive(true);
		}
		this.ZombieSpawner.enabled = true;
		this.Yanmont.CanMove = true;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x0400474E RID: 18254
	public YanvaniaZombieSpawnerScript ZombieSpawner;

	// Token: 0x0400474F RID: 18255
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004750 RID: 18256
	public GameObject Jukebox;

	// Token: 0x04004751 RID: 18257
	public Transform BlackRight;

	// Token: 0x04004752 RID: 18258
	public Transform BlackLeft;

	// Token: 0x04004753 RID: 18259
	public UILabel FinalStage;

	// Token: 0x04004754 RID: 18260
	public UILabel Heartbreak;

	// Token: 0x04004755 RID: 18261
	public UITexture Triangle;

	// Token: 0x04004756 RID: 18262
	public float LeaveTime;

	// Token: 0x04004757 RID: 18263
	public float Position;

	// Token: 0x04004758 RID: 18264
	public float Timer;
}
