// Decompiled with JetBrains decompiler
// Type: FootprintSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FootprintSpawnerScript : MonoBehaviour
{
  public YandereScript Yandere;
  public GameObject BloodyFootprint;
  public AudioClip[] WalkFootsteps;
  public AudioClip[] RunFootsteps;
  public AudioClip[] WalkBareFootsteps;
  public AudioClip[] RunBareFootsteps;
  public AudioSource MyAudio;
  public Transform BloodParent;
  public Collider MyCollider;
  public Collider GardenArea;
  public Collider PoolStairs;
  public Collider TreeArea;
  public Collider NEStairs;
  public Collider NWStairs;
  public Collider SEStairs;
  public Collider SWStairs;
  public bool Debugging;
  public bool CanSpawn;
  public bool FootUp;
  public float DownThreshold;
  public float UpThreshold;
  public float Height;
  public int Bloodiness;
  public int Collisions;
  public int StudentBloodID;

  private void Start()
  {
    if ((Object) this.MyAudio == (Object) null)
      this.MyAudio = this.GetComponent<AudioSource>();
    this.GardenArea = this.Yandere.StudentManager.GardenArea;
    this.PoolStairs = this.Yandere.StudentManager.PoolStairs;
    this.TreeArea = this.Yandere.StudentManager.TreeArea;
    this.NEStairs = this.Yandere.StudentManager.NEStairs;
    this.NWStairs = this.Yandere.StudentManager.NWStairs;
    this.SEStairs = this.Yandere.StudentManager.SEStairs;
    this.SWStairs = this.Yandere.StudentManager.SWStairs;
  }

  private void Update()
  {
    if (!this.FootUp)
    {
      if ((double) this.transform.position.y <= (double) this.Yandere.transform.position.y + (double) this.UpThreshold)
        return;
      this.FootUp = true;
    }
    else
    {
      if ((double) this.transform.position.y >= (double) this.Yandere.transform.position.y + (double) this.DownThreshold)
        return;
      if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp)
      {
        if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || this.Yandere.ClubAttire && this.Yandere.Club == ClubType.MartialArts)
        {
          if (this.Yandere.Running)
          {
            this.MyAudio.clip = this.RunBareFootsteps[Random.Range(0, this.RunBareFootsteps.Length)];
            this.MyAudio.volume = 0.3f;
          }
          else
          {
            this.MyAudio.clip = this.WalkBareFootsteps[Random.Range(0, this.WalkBareFootsteps.Length)];
            this.MyAudio.volume = 0.2f;
          }
        }
        else if (this.Yandere.Running)
        {
          this.MyAudio.clip = this.RunFootsteps[Random.Range(0, this.RunFootsteps.Length)];
          this.MyAudio.volume = 0.15f;
        }
        else
        {
          this.MyAudio.clip = this.WalkFootsteps[Random.Range(0, this.WalkFootsteps.Length)];
          this.MyAudio.volume = 0.1f;
        }
        this.MyAudio.Play();
      }
      this.FootUp = false;
      if (this.Bloodiness <= 0)
        return;
      Bounds bounds = this.GardenArea.bounds;
      int num;
      if (!bounds.Contains(this.transform.position))
      {
        bounds = this.PoolStairs.bounds;
        if (!bounds.Contains(this.transform.position))
        {
          bounds = this.TreeArea.bounds;
          if (!bounds.Contains(this.transform.position))
          {
            bounds = this.NEStairs.bounds;
            if (!bounds.Contains(this.transform.position))
            {
              bounds = this.NWStairs.bounds;
              if (!bounds.Contains(this.transform.position))
              {
                bounds = this.SEStairs.bounds;
                if (!bounds.Contains(this.transform.position))
                {
                  bounds = this.SWStairs.bounds;
                  num = !bounds.Contains(this.transform.position) ? 1 : 0;
                  goto label_22;
                }
              }
            }
          }
        }
      }
      num = 0;
label_22:
      this.CanSpawn = num != 0;
      if (!this.CanSpawn)
        return;
      if ((double) this.transform.position.y > -1.0 && (double) this.transform.position.y < 1.0)
        this.Height = 0.0f;
      else if ((double) this.transform.position.y > 3.0 && (double) this.transform.position.y < 5.0)
        this.Height = 4f;
      else if ((double) this.transform.position.y > 7.0 && (double) this.transform.position.y < 9.0)
        this.Height = 8f;
      else if ((double) this.transform.position.y > 11.0 && (double) this.transform.position.y < 13.0)
        this.Height = 12f;
      GameObject gameObject = Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
      gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, this.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
      FootprintScript component = gameObject.transform.GetChild(0).GetComponent<FootprintScript>();
      gameObject.transform.parent = this.BloodParent;
      component.Yandere = this.Yandere;
      component.StudentBloodID = this.StudentBloodID;
      --this.Bloodiness;
    }
  }
}
