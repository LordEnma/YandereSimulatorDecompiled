using System;
using System.Xml.Serialization;

// Token: 0x02000408 RID: 1032
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400318A RID: 12682
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400318B RID: 12683
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400318C RID: 12684
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400318D RID: 12685
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400318E RID: 12686
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x0400318F RID: 12687
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003190 RID: 12688
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003191 RID: 12689
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003192 RID: 12690
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003193 RID: 12691
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003194 RID: 12692
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003195 RID: 12693
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003196 RID: 12694
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003197 RID: 12695
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003198 RID: 12696
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003199 RID: 12697
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400319A RID: 12698
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x0400319B RID: 12699
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x0400319C RID: 12700
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x0400319D RID: 12701
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x0400319E RID: 12702
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
