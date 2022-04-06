using System;
using System.Xml.Serialization;

// Token: 0x0200040E RID: 1038
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x04003200 RID: 12800
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x04003201 RID: 12801
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x04003202 RID: 12802
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x04003203 RID: 12803
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x04003204 RID: 12804
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x04003205 RID: 12805
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003206 RID: 12806
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003207 RID: 12807
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003208 RID: 12808
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003209 RID: 12809
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x0400320A RID: 12810
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x0400320B RID: 12811
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x0400320C RID: 12812
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x0400320D RID: 12813
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x0400320E RID: 12814
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x0400320F RID: 12815
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x04003210 RID: 12816
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x04003211 RID: 12817
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x04003212 RID: 12818
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x04003213 RID: 12819
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x04003214 RID: 12820
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
