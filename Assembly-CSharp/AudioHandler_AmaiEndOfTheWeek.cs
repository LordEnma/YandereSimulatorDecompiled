using UnityEngine;

public class AudioHandler_AmaiEndOfTheWeek : MonoBehaviour
{
	public GameObject voiceline01;

	public GameObject voiceline02;

	public GameObject voiceline03;

	public GameObject SenpaiShrinePic;

	public GameObject Sfx01;

	public GameObject Sfx02;

	public GameObject FreezerTime01;

	public GameObject FreezerTime02;

	public GameObject VisiblePhone;

	public GameObject AyanoAnim01;

	public GameObject AyanoAnim02;

	public GameObject Cucumberanim01;

	public GameObject Cucumberanim02;

	private void Start()
	{
		voiceline01.SetActive(value: false);
		voiceline02.SetActive(value: false);
		SenpaiShrinePic.SetActive(value: false);
		Sfx01.SetActive(value: false);
		AyanoAnim01.SetActive(value: true);
		AyanoAnim02.SetActive(value: false);
		Cucumberanim01.SetActive(value: true);
		Cucumberanim02.SetActive(value: false);
		FreezerTime01.SetActive(value: true);
		FreezerTime02.SetActive(value: false);
		VisiblePhone.SetActive(value: false);
	}

	public void LDOTW_Amai_AyanoStartHum()
	{
		voiceline01.SetActive(value: true);
	}

	public void LDOTW_Amai_AyanoStartTalk()
	{
		voiceline02.SetActive(value: true);
	}

	public void LDOTW_Amai_enableSenpai()
	{
		SenpaiShrinePic.SetActive(value: true);
	}

	public void LDOTW_Amai_Playsoundeffect01()
	{
		Sfx01.SetActive(value: true);
	}

	public void changeAnimations_AmaiEndOfWeek()
	{
		AyanoAnim01.SetActive(value: false);
		AyanoAnim02.SetActive(value: true);
		Cucumberanim01.SetActive(value: false);
		Cucumberanim02.SetActive(value: true);
	}

	public void CallChangeInTimeFreezer_AmaiEndOfWeek()
	{
		FreezerTime02.SetActive(value: true);
		FreezerTime01.SetActive(value: false);
	}

	public void SetPhoneVisible_AmaiEndOfWeek()
	{
		VisiblePhone.SetActive(value: true);
	}

	public void ShutUp()
	{
		Debug.Log("Just told everything to shut up...");
		voiceline01.SetActive(value: false);
		voiceline02.SetActive(value: false);
		SenpaiShrinePic.SetActive(value: false);
		Sfx01.SetActive(value: false);
		AyanoAnim01.SetActive(value: false);
		AyanoAnim02.SetActive(value: false);
		Cucumberanim01.SetActive(value: false);
		Cucumberanim02.SetActive(value: false);
		FreezerTime01.SetActive(value: false);
		FreezerTime02.SetActive(value: false);
		VisiblePhone.SetActive(value: false);
		base.transform.parent.gameObject.SetActive(value: false);
		base.enabled = false;
	}
}
