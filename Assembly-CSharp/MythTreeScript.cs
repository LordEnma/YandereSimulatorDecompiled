using UnityEngine;

public class MythTreeScript : MonoBehaviour
{
	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public bool Spoken;

	public AudioSource MyAudio;

	public TreeBranchAnimationScript[] TreeBranch;

	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		if (!Spoken)
		{
			if (Yandere.Inventory.Ring && Vector3.Distance(Yandere.transform.position, base.transform.position) < 5f)
			{
				TreeBranch[0].Min = -15f;
				TreeBranch[0].Max = 15f;
				TreeBranch[1].Min = -15f;
				TreeBranch[1].Max = 15f;
				TreeBranch[2].Min = -15f;
				TreeBranch[2].Max = 15f;
				TreeBranch[3].Min = -15f;
				TreeBranch[3].Max = 15f;
				TreeBranch[4].Min = -15f;
				TreeBranch[4].Max = 15f;
				EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				EventSubtitle.text = "...that...ring...";
				Jukebox.Dip = 0.5f;
				Spoken = true;
				MyAudio.Play();
			}
		}
		else if (!MyAudio.isPlaying)
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			EventSubtitle.text = string.Empty;
			Jukebox.Dip = 1f;
			Object.Destroy(this);
		}
	}
}
