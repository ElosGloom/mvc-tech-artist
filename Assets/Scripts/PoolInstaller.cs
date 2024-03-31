using Modules.Profile.View;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    private const string PoolablesPath = "Poolables/";

    public override void InstallBindings()
    {
        BindAchievementGroupFactory();
        BindAchievementCellFactory();
        BindMatchButtonFactory();
        BindMatchParameterCellFactory();
    }

    private void BindMatchParameterCellFactory()
    {
        Container.BindFactory<MatchParametersProtocol, MatchParameterCellView, MatchParameterCellView.Factory>()
            .FromPoolableMemoryPool<MatchParametersProtocol, MatchParameterCellView, MatchParameterCellView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(3)
                        .FromComponentInNewPrefabResource($"{PoolablesPath}{nameof(MatchParameterCellView)}")
                        .UnderTransformGroup(nameof(MatchParameterCellView)));
    }

    private void BindMatchButtonFactory()
    {
        Container.BindFactory<MatchButtonProtocol, MatchButtonView, MatchButtonView.Factory>()
            .FromPoolableMemoryPool<MatchButtonProtocol, MatchButtonView, MatchButtonView.Pool>(poolBinder =>
                poolBinder
                    .WithInitialSize(3)
                    .FromComponentInNewPrefabResource($"{PoolablesPath}{nameof(MatchButtonView)}")
                    .UnderTransformGroup(nameof(MatchButtonView)));
    }

    private void BindAchievementCellFactory()
    {
        Container.BindFactory<AchievementCellProtocol, AchievementCellView, AchievementCellView.Factory>()
            .FromPoolableMemoryPool<AchievementCellProtocol, AchievementCellView, AchievementCellView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(5)
                        .FromComponentInNewPrefabResource($"{PoolablesPath}{nameof(AchievementCellView)}")
                        .UnderTransformGroup(nameof(AchievementCellView)));
    }

    private void BindAchievementGroupFactory()
    {
        Container.BindFactory<AchievementsGroupView, AchievementsGroupView.Factory>()
            .FromPoolableMemoryPool<AchievementsGroupView, AchievementsGroupView.Pool>(
                poolBinder =>
                    poolBinder
                        .WithInitialSize(4)
                        .FromComponentInNewPrefabResource($"{PoolablesPath}{nameof(AchievementsGroupView)}")
                        .UnderTransformGroup(nameof(AchievementsGroupView)));
    }
}