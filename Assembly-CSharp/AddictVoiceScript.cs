using UnityEngine;

public class AddictVoiceScript : MonoBehaviour
{
	public AudioClip[] VoiceClip;

	public string[] Text;

	public UILabel Subtitle;

	public void PlayVoice(AudioSource MyAudio)
	{
		int num = Random.Range(0, VoiceClip.Length);
		while (Text[num] == "")
		{
			num = Random.Range(0, VoiceClip.Length);
		}
		MyAudio.clip = VoiceClip[num];
		MyAudio.Play();
		Subtitle.text = Text[num];
	}
}
