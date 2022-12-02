using UnityEngine;

public class YanvaniaCutsceneTriggerScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject BossBattleWall;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			BossBattleWall.SetActive(true);
			Yanmont.EnterCutscene = true;
			Object.Destroy(base.gameObject);
		}
	}
}
