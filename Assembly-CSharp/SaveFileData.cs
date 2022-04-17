using System;
using System.Xml.Serialization;

// Token: 0x0200040E RID: 1038
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x0400320B RID: 12811
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x0400320C RID: 12812
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x0400320D RID: 12813
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x0400320E RID: 12814
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x0400320F RID: 12815
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x04003210 RID: 12816
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x04003211 RID: 12817
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x04003212 RID: 12818
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x04003213 RID: 12819
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x04003214 RID: 12820
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x04003215 RID: 12821
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x04003216 RID: 12822
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003217 RID: 12823
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003218 RID: 12824
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003219 RID: 12825
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x0400321A RID: 12826
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x0400321B RID: 12827
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x0400321C RID: 12828
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x0400321D RID: 12829
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x0400321E RID: 12830
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x0400321F RID: 12831
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
