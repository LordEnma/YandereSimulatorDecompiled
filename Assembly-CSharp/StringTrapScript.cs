using System;
using UnityEngine;

// Token: 0x02000455 RID: 1109
public class StringTrapScript : MonoBehaviour
{
	// Token: 0x06001D66 RID: 7526 RVA: 0x00161844 File Offset: 0x0015FA44
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

	// Token: 0x0400360B RID: 13835
	public WaterCoolerScript WaterCooler;

	// Token: 0x0400360C RID: 13836
	public GameObject BrownPaintPuddle;

	// Token: 0x0400360D RID: 13837
	public GameObject GasolinePuddle;

	// Token: 0x0400360E RID: 13838
	public GameObject BloodPuddle;

	// Token: 0x0400360F RID: 13839
	public GameObject WaterPuddle;

	// Token: 0x04003610 RID: 13840
	public GameObject BrownPaint;

	// Token: 0x04003611 RID: 13841
	public GameObject Gasoline;

	// Token: 0x04003612 RID: 13842
	public GameObject Blood;

	// Token: 0x04003613 RID: 13843
	public GameObject Water;

	// Token: 0x04003614 RID: 13844
	public GameObject Puddle;

	// Token: 0x04003615 RID: 13845
	public Transform[] PuddleSpawn;

	// Token: 0x04003616 RID: 13846
	public Transform Spawn;
}
