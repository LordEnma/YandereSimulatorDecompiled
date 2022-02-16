using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014AD RID: 5293 RVA: 0x000CB280 File Offset: 0x000C9480
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

	// Token: 0x060014AE RID: 5294 RVA: 0x000CB344 File Offset: 0x000C9544
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

	// Token: 0x04002058 RID: 8280
	public YandereScript Yandere;

	// Token: 0x04002059 RID: 8281
	public GameObject BloodyFootprint;

	// Token: 0x0400205A RID: 8282
	public AudioClip[] WalkFootsteps;

	// Token: 0x0400205B RID: 8283
	public AudioClip[] RunFootsteps;

	// Token: 0x0400205C RID: 8284
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x0400205D RID: 8285
	public AudioClip[] RunBareFootsteps;

	// Token: 0x0400205E RID: 8286
	public AudioSource MyAudio;

	// Token: 0x0400205F RID: 8287
	public Transform BloodParent;

	// Token: 0x04002060 RID: 8288
	public Collider MyCollider;

	// Token: 0x04002061 RID: 8289
	public Collider GardenArea;

	// Token: 0x04002062 RID: 8290
	public Collider PoolStairs;

	// Token: 0x04002063 RID: 8291
	public Collider TreeArea;

	// Token: 0x04002064 RID: 8292
	public Collider NEStairs;

	// Token: 0x04002065 RID: 8293
	public Collider NWStairs;

	// Token: 0x04002066 RID: 8294
	public Collider SEStairs;

	// Token: 0x04002067 RID: 8295
	public Collider SWStairs;

	// Token: 0x04002068 RID: 8296
	public bool Debugging;

	// Token: 0x04002069 RID: 8297
	public bool CanSpawn;

	// Token: 0x0400206A RID: 8298
	public bool FootUp;

	// Token: 0x0400206B RID: 8299
	public float DownThreshold;

	// Token: 0x0400206C RID: 8300
	public float UpThreshold;

	// Token: 0x0400206D RID: 8301
	public float Height;

	// Token: 0x0400206E RID: 8302
	public int Bloodiness;

	// Token: 0x0400206F RID: 8303
	public int Collisions;
}
