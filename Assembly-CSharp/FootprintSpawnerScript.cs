using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014B9 RID: 5305 RVA: 0x000CC150 File Offset: 0x000CA350
	private void Start()
	{
		if (this.MyAudio == null)
		{
			this.MyAudio = base.GetComponent<AudioSource>();
		}
		this.GardenArea = this.Yandere.StudentManager.GardenArea;
		this.PoolStairs = this.Yandere.StudentManager.PoolStairs;
		this.TreeArea = this.Yandere.StudentManager.TreeArea;
		this.NEStairs = this.Yandere.StudentManager.NEStairs;
		this.NWStairs = this.Yandere.StudentManager.NWStairs;
		this.SEStairs = this.Yandere.StudentManager.SEStairs;
		this.SWStairs = this.Yandere.StudentManager.SWStairs;
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x000CC214 File Offset: 0x000CA414
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp)
			{
				if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2)
				{
					if (this.Yandere.Running)
					{
						this.MyAudio.clip = this.RunBareFootsteps[UnityEngine.Random.Range(0, this.RunBareFootsteps.Length)];
						this.MyAudio.volume = 0.3f;
					}
					else
					{
						this.MyAudio.clip = this.WalkBareFootsteps[UnityEngine.Random.Range(0, this.WalkBareFootsteps.Length)];
						this.MyAudio.volume = 0.2f;
					}
				}
				else if (this.Yandere.Running)
				{
					this.MyAudio.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
					this.MyAudio.volume = 0.15f;
				}
				else
				{
					this.MyAudio.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
					this.MyAudio.volume = 0.1f;
				}
				this.MyAudio.Play();
			}
			this.FootUp = false;
			if (this.Bloodiness > 0)
			{
				this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.PoolStairs.bounds.Contains(base.transform.position) && !this.TreeArea.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
				if (this.CanSpawn)
				{
					if (base.transform.position.y > -1f && base.transform.position.y < 1f)
					{
						this.Height = 0f;
					}
					else if (base.transform.position.y > 3f && base.transform.position.y < 5f)
					{
						this.Height = 4f;
					}
					else if (base.transform.position.y > 7f && base.transform.position.y < 9f)
					{
						this.Height = 8f;
					}
					else if (base.transform.position.y > 11f && base.transform.position.y < 13f)
					{
						this.Height = 12f;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
					gameObject.transform.parent = this.BloodParent;
					this.Bloodiness--;
				}
			}
		}
	}

	// Token: 0x04002081 RID: 8321
	public YandereScript Yandere;

	// Token: 0x04002082 RID: 8322
	public GameObject BloodyFootprint;

	// Token: 0x04002083 RID: 8323
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002084 RID: 8324
	public AudioClip[] RunFootsteps;

	// Token: 0x04002085 RID: 8325
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002086 RID: 8326
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002087 RID: 8327
	public AudioSource MyAudio;

	// Token: 0x04002088 RID: 8328
	public Transform BloodParent;

	// Token: 0x04002089 RID: 8329
	public Collider MyCollider;

	// Token: 0x0400208A RID: 8330
	public Collider GardenArea;

	// Token: 0x0400208B RID: 8331
	public Collider PoolStairs;

	// Token: 0x0400208C RID: 8332
	public Collider TreeArea;

	// Token: 0x0400208D RID: 8333
	public Collider NEStairs;

	// Token: 0x0400208E RID: 8334
	public Collider NWStairs;

	// Token: 0x0400208F RID: 8335
	public Collider SEStairs;

	// Token: 0x04002090 RID: 8336
	public Collider SWStairs;

	// Token: 0x04002091 RID: 8337
	public bool Debugging;

	// Token: 0x04002092 RID: 8338
	public bool CanSpawn;

	// Token: 0x04002093 RID: 8339
	public bool FootUp;

	// Token: 0x04002094 RID: 8340
	public float DownThreshold;

	// Token: 0x04002095 RID: 8341
	public float UpThreshold;

	// Token: 0x04002096 RID: 8342
	public float Height;

	// Token: 0x04002097 RID: 8343
	public int Bloodiness;

	// Token: 0x04002098 RID: 8344
	public int Collisions;
}
