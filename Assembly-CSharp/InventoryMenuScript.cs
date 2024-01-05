using UnityEngine;

public class InventoryMenuScript : MonoBehaviour
{
	public TaskManagerScript TaskManager;

	public PauseScreenScript PauseScreen;

	public InventoryScript Inventory;

	public GameObject[] Categories;

	public Transform Highlight;

	public UITexture[] Icons;

	public UILabel[] Labels;

	public string[] EightiesTaskItemNames;

	public int Category;

	public void Update()
	{
		if (PauseScreen.InputManager.TappedRight)
		{
			Category++;
			if (Category == Categories.Length)
			{
				Category = 1;
			}
			UpdateCategory();
		}
		else if (PauseScreen.InputManager.TappedLeft)
		{
			Category--;
			if (Category == 0)
			{
				Category = Categories.Length - 1;
			}
			UpdateCategory();
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateCategory()
	{
		Categories[1].SetActive(value: false);
		Categories[2].SetActive(value: false);
		Categories[3].SetActive(value: false);
		Categories[4].SetActive(value: false);
		Categories[Category].SetActive(value: true);
		if (Category == 1)
		{
			Highlight.localPosition = new Vector3(-400f, 249f, 0f);
		}
		else if (Category == 2)
		{
			Highlight.localPosition = new Vector3(-150f, 249f, 0f);
		}
		else if (Category == 3)
		{
			Highlight.localPosition = new Vector3(150f, 249f, 0f);
		}
		else if (Category == 4)
		{
			Highlight.localPosition = new Vector3(400f, 249f, 0f);
		}
	}

	public void UpdateLabels()
	{
		for (int i = 1; i < 11; i++)
		{
			Labels[i].alpha = ((Inventory.ItemsCollected[i] == 0) ? 0.75f : 1f);
			Labels[i].text = EightiesTaskItemNames[i] + ": " + Inventory.ItemsCollected[i];
		}
		Labels[11].alpha = ((!Inventory.Book) ? 0.75f : 1f);
		Labels[12].alpha = ((!Inventory.ModifiedUniform) ? 0.75f : 1f);
		Labels[13].alpha = ((!Inventory.TapePlayer) ? 0.75f : 1f);
		Labels[14].alpha = ((!Inventory.PinkCloth) ? 0.75f : 1f);
		Labels[15].alpha = ((!Inventory.PinkSocks) ? 0.75f : 1f);
		Labels[16].alpha = ((!Inventory.Bikini) ? 0.75f : 1f);
		Labels[17].alpha = ((TaskManager.TaskStatus[4] != 2) ? 0.75f : 1f);
		Labels[18].alpha = ((TaskManager.TaskStatus[11] != 2) ? 0.75f : 1f);
		Labels[19].alpha = ((TaskManager.TaskStatus[41] != 2) ? 0.75f : 1f);
		Labels[20].alpha = ((TaskManager.TaskStatus[37] != 2) ? 0.75f : 1f);
		Labels[21].alpha = ((TaskManager.TaskStatus[25] != 2) ? 0.75f : 1f);
		Labels[23].alpha = ((!Inventory.DirectionalMic) ? 0.75f : 1f);
		Labels[24].alpha = ((!Inventory.DuplicateSheet) ? 0.75f : 1f);
		Labels[25].alpha = ((!Inventory.IDCard) ? 0.75f : 1f);
		Labels[26].alpha = ((!Inventory.AnswerSheet) ? 0.75f : 1f);
		Labels[27].alpha = ((!Inventory.MaskingTape) ? 0.75f : 1f);
		Labels[28].alpha = ((!Inventory.RivalPhone) ? 0.75f : 1f);
		Labels[29].alpha = ((!Inventory.Ring) ? 0.75f : 1f);
		Labels[30].alpha = ((!Inventory.Cigs) ? 0.75f : 1f);
		Labels[31].alpha = ((!Inventory.Narcotics) ? 0.75f : 1f);
		Labels[32].alpha = ((!Inventory.LockPick) ? 0.75f : 1f);
		Labels[33].alpha = ((!Inventory.Sake) ? 0.75f : 1f);
		Labels[34].alpha = ((!Inventory.Condoms) ? 0.75f : 1f);
		Labels[35].alpha = ((!Inventory.FakeID) ? 0.75f : 1f);
		Labels[36].alpha = ((!Inventory.Headset) ? 0.75f : 1f);
		Labels[37].alpha = ((!Inventory.String) ? 0.75f : 1f);
		Labels[39].alpha = ((!Inventory.Ammonium) ? 0.75f : 1f);
		Labels[40].alpha = ((!Inventory.Balloons) ? 0.75f : 1f);
		Labels[41].alpha = ((!Inventory.Bandages) ? 0.75f : 1f);
		Labels[42].alpha = ((!Inventory.Glass) ? 0.75f : 1f);
		Labels[43].alpha = ((!Inventory.Hairpins) ? 0.75f : 1f);
		Labels[44].alpha = ((!Inventory.Nails) ? 0.75f : 1f);
		Labels[45].alpha = ((!Inventory.Paper) ? 0.75f : 1f);
		Labels[46].alpha = ((!Inventory.PaperClips) ? 0.75f : 1f);
		Labels[47].alpha = ((!Inventory.SilverFulminate) ? 0.75f : 1f);
		Labels[48].alpha = ((!Inventory.WoodenSticks) ? 0.75f : 1f);
		Labels[49].alpha = ((!Inventory.Mustard) ? 0.75f : 1f);
		Labels[50].alpha = ((!Inventory.Salt) ? 0.75f : 1f);
		Labels[51].alpha = ((!Inventory.Tyramine) ? 0.75f : 1f);
		Labels[52].alpha = ((!Inventory.Phenylethylamine) ? 0.75f : 1f);
		Labels[53].alpha = ((!Inventory.Acetone) ? 0.75f : 1f);
		Labels[54].alpha = ((!Inventory.Chloroform) ? 0.75f : 1f);
		Labels[55].alpha = ((!Inventory.AceticAcid) ? 0.75f : 1f);
		Labels[56].alpha = ((!Inventory.BariumCarbonate) ? 0.75f : 1f);
		Labels[57].alpha = ((!Inventory.PotassiumNitrate) ? 0.75f : 1f);
		Labels[58].alpha = ((!Inventory.Sugar) ? 0.75f : 1f);
		Labels[60].alpha = ((Inventory.LethalPoisons == 0) ? 0.75f : 1f);
		Labels[60].text = "Lethal Poisons: " + Inventory.LethalPoisons;
		Labels[61].alpha = ((Inventory.EmeticPoisons == 0) ? 0.75f : 1f);
		Labels[61].text = "Emetic Poisons: " + Inventory.EmeticPoisons;
		Labels[62].alpha = ((Inventory.HeadachePoisons == 0) ? 0.75f : 1f);
		Labels[62].text = "Headache Poisons: " + Inventory.HeadachePoisons;
		Labels[63].alpha = ((Inventory.SedativePoisons == 0) ? 0.75f : 1f);
		Labels[63].text = "Sedatives: " + Inventory.SedativePoisons;
		Labels[64].alpha = ((!Inventory.LethalSeeds) ? 0.75f : 1f);
		Labels[65].alpha = ((!Inventory.EmeticSeeds) ? 0.75f : 1f);
		Labels[66].alpha = ((!Inventory.HeadacheSeeds) ? 0.75f : 1f);
		Labels[67].alpha = ((!Inventory.SedativeSeeds) ? 0.75f : 1f);
		Labels[68].alpha = ((!Inventory.GrowthStimulant) ? 0.75f : 1f);
		Labels[69].alpha = ((!Inventory.ShedKey) ? 0.75f : 1f);
		Labels[70].alpha = ((!Inventory.SafeKey) ? 0.75f : 1f);
		Labels[71].alpha = ((!Inventory.CaseKey) ? 0.75f : 1f);
		for (int i = 1; i < Icons.Length; i++)
		{
			if (Icons[i] != null)
			{
				Icons[i].alpha = Labels[i].alpha;
			}
		}
	}
}
