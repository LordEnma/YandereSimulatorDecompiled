using System;
using UnityEngine;

// Token: 0x02000457 RID: 1111
public class StringTrapScript : MonoBehaviour
{
	// Token: 0x06001D73 RID: 7539 RVA: 0x00162D54 File Offset: 0x00160F54
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A character just came into contact with a tripwire trap!");
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if ((component != null && component.Club == ClubType.Council) || (component != null && component.Teacher))
			{
				this.WaterCooler.Yandere.NotificationManager.CustomText = "Tripwire Trap Dismantled!";
				this.WaterCooler.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				this.WaterCooler.Yandere.Subtitle.CustomText = "Someone tried to pull a prank? How childish...";
				this.WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				base.transform.parent.gameObject.SetActive(false);
				this.WaterCooler.Prompt.HideButton[3] = false;
				this.WaterCooler.PickUp.enabled = true;
				this.WaterCooler.Prompt.enabled = true;
				this.WaterCooler.TrapSet = false;
				this.WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
				this.WaterCooler.Prompt.Label[1].applyGradient = false;
				this.WaterCooler.Prompt.Label[1].color = Color.red;
				return;
			}
			if (this.WaterCooler.BrownPaint)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.BrownPaint, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.BrownPaintPuddle;
			}
			else if (this.WaterCooler.Blood)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Blood, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.BloodPuddle;
			}
			else if (this.WaterCooler.Gasoline)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Gasoline, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.GasolinePuddle;
			}
			else
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Water, this.Spawn.position, this.WaterCooler.transform.rotation);
				this.Puddle = this.WaterPuddle;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[1].position, Quaternion.identity);
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[2].position, Quaternion.identity);
			GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.Puddle, this.PuddleSpawn[3].position, Quaternion.identity);
			gameObject.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject2.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject3.transform.eulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			if (this.WaterCooler.Blood)
			{
				gameObject.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
				gameObject2.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
				gameObject3.transform.parent = this.WaterCooler.Yandere.Police.BloodParent;
			}
			else
			{
				gameObject.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
				gameObject2.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
				gameObject3.transform.parent = this.WaterCooler.Yandere.StudentManager.PuddleParent.transform;
			}
			this.WaterCooler.Prompt.enabled = true;
			this.WaterCooler.BrownPaint = false;
			this.WaterCooler.Blood = false;
			this.WaterCooler.Gasoline = false;
			this.WaterCooler.Water = false;
			this.WaterCooler.TrapSet = false;
			this.WaterCooler.Empty = true;
			this.WaterCooler.Timer = 1f;
			this.WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
			this.WaterCooler.Prompt.Label[1].applyGradient = false;
			this.WaterCooler.Prompt.Label[1].color = Color.red;
			base.transform.parent.gameObject.SetActive(false);
			this.WaterCooler.Prompt.HideButton[3] = false;
			this.WaterCooler.PickUp.enabled = true;
			this.WaterCooler.MyRigidbody.isKinematic = false;
		}
	}

	// Token: 0x0400362F RID: 13871
	public WaterCoolerScript WaterCooler;

	// Token: 0x04003630 RID: 13872
	public GameObject BrownPaintPuddle;

	// Token: 0x04003631 RID: 13873
	public GameObject GasolinePuddle;

	// Token: 0x04003632 RID: 13874
	public GameObject BloodPuddle;

	// Token: 0x04003633 RID: 13875
	public GameObject WaterPuddle;

	// Token: 0x04003634 RID: 13876
	public GameObject BrownPaint;

	// Token: 0x04003635 RID: 13877
	public GameObject Gasoline;

	// Token: 0x04003636 RID: 13878
	public GameObject Blood;

	// Token: 0x04003637 RID: 13879
	public GameObject Water;

	// Token: 0x04003638 RID: 13880
	public GameObject Puddle;

	// Token: 0x04003639 RID: 13881
	public Transform[] PuddleSpawn;

	// Token: 0x0400363A RID: 13882
	public Transform Spawn;
}
