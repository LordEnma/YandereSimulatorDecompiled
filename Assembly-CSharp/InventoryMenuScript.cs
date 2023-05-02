using UnityEngine;

public class InventoryMenuScript : MonoBehaviour
{
	public TaskManagerScript TaskManager;

	public PauseScreenScript PauseScreen;

	public InventoryScript Inventory;

	public UILabel[] Labels;

	public void UpdateLabels()
	{
		Labels[1].alpha = ((!Inventory.Book) ? 0.75f : 1f);
		Labels[2].alpha = ((!Inventory.FinishedHomework) ? 0.75f : 1f);
		Labels[3].alpha = ((!Inventory.ModifiedUniform) ? 0.75f : 1f);
		Labels[4].alpha = ((!Inventory.Soda) ? 0.75f : 1f);
		Labels[5].alpha = ((TaskManager.TaskStatus[41] != 2) ? 0.75f : 1f);
		Labels[6].alpha = ((TaskManager.TaskStatus[4] != 2) ? 0.75f : 1f);
		Labels[7].alpha = ((TaskManager.TaskStatus[11] != 2) ? 0.75f : 1f);
		Labels[8].alpha = ((TaskManager.TaskStatus[37] != 2) ? 0.75f : 1f);
		Labels[9].alpha = ((TaskManager.TaskStatus[25] != 2) ? 0.75f : 1f);
		Labels[11].alpha = ((!Inventory.DirectionalMic) ? 0.75f : 1f);
		Labels[12].alpha = ((!Inventory.DuplicateSheet) ? 0.75f : 1f);
		Labels[13].alpha = ((!Inventory.IDCard) ? 0.75f : 1f);
		Labels[14].alpha = ((!Inventory.AnswerSheet) ? 0.75f : 1f);
		Labels[15].alpha = ((!Inventory.MaskingTape) ? 0.75f : 1f);
		Labels[16].alpha = ((!Inventory.RivalPhone) ? 0.75f : 1f);
		Labels[17].alpha = ((!Inventory.Ring) ? 0.75f : 1f);
		Labels[18].alpha = ((!Inventory.Cigs) ? 0.75f : 1f);
		Labels[19].alpha = ((!Inventory.Narcotics) ? 0.75f : 1f);
		Labels[20].alpha = ((!Inventory.LockPick) ? 0.75f : 1f);
		Labels[21].alpha = ((!Inventory.Sake) ? 0.75f : 1f);
		Labels[22].alpha = ((!Inventory.Condoms) ? 0.75f : 1f);
		Labels[23].alpha = ((!Inventory.FakeID) ? 0.75f : 1f);
		Labels[24].alpha = ((!Inventory.Headset) ? 0.75f : 1f);
		Labels[25].alpha = ((!Inventory.String) ? 0.75f : 1f);
		Labels[26].alpha = ((!Inventory.Ammonium) ? 0.75f : 1f);
		Labels[27].alpha = ((!Inventory.Balloons) ? 0.75f : 1f);
		Labels[28].alpha = ((!Inventory.Bandages) ? 0.75f : 1f);
		Labels[29].alpha = ((!Inventory.Glass) ? 0.75f : 1f);
		Labels[30].alpha = ((!Inventory.Hairpins) ? 0.75f : 1f);
		Labels[31].alpha = ((!Inventory.Nails) ? 0.75f : 1f);
		Labels[32].alpha = ((!Inventory.Paper) ? 0.75f : 1f);
		Labels[33].alpha = ((!Inventory.PaperClips) ? 0.75f : 1f);
		Labels[34].alpha = ((!Inventory.SilverFulminate) ? 0.75f : 1f);
		Labels[35].alpha = ((!Inventory.WoodenSticks) ? 0.75f : 1f);
		Labels[36].alpha = ((!Inventory.Mustard) ? 0.75f : 1f);
		Labels[37].alpha = ((!Inventory.Salt) ? 0.75f : 1f);
		Labels[38].alpha = ((!Inventory.Tyramine) ? 0.75f : 1f);
		Labels[39].alpha = ((!Inventory.Phenylethylamine) ? 0.75f : 1f);
		Labels[40].alpha = ((!Inventory.Acetone) ? 0.75f : 1f);
		Labels[41].alpha = ((!Inventory.Chloroform) ? 0.75f : 1f);
		Labels[42].alpha = ((!Inventory.AceticAcid) ? 0.75f : 1f);
		Labels[43].alpha = ((!Inventory.BariumCarbonate) ? 0.75f : 1f);
		Labels[44].alpha = ((!Inventory.PotassiumNitrate) ? 0.75f : 1f);
		Labels[45].alpha = ((!Inventory.Sugar) ? 0.75f : 1f);
		Labels[46].alpha = ((Inventory.LethalPoisons == 0) ? 0.75f : 1f);
		Labels[46].text = "Lethal Poisons: " + Inventory.LethalPoisons;
		Labels[47].alpha = ((Inventory.EmeticPoisons == 0) ? 0.75f : 1f);
		Labels[47].text = "Emetic Poisons: " + Inventory.EmeticPoisons;
		Labels[48].alpha = ((Inventory.HeadachePoisons == 0) ? 0.75f : 1f);
		Labels[48].text = "Headache Poisons: " + Inventory.HeadachePoisons;
		Labels[49].alpha = ((Inventory.SedativePoisons == 0) ? 0.75f : 1f);
		Labels[49].text = "Sedatives: " + Inventory.SedativePoisons;
		Labels[51].alpha = ((!Inventory.ShedKey) ? 0.75f : 1f);
		Labels[52].alpha = ((!Inventory.CabinetKey) ? 0.75f : 1f);
		Labels[53].alpha = ((!Inventory.SafeKey) ? 0.75f : 1f);
		Labels[54].alpha = ((!Inventory.CaseKey) ? 0.75f : 1f);
	}

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PauseScreen.MainMenu.SetActive(value: true);
			PauseScreen.Sideways = false;
			base.gameObject.SetActive(value: false);
		}
	}
}
