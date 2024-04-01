using UnityEngine;
using Zenject;

namespace Modules.Profile.View
{
    public class AchievementsGroupView : MonoBehaviour, IPoolable<IMemoryPool>, IClearable
    {
        private IMemoryPool m_pool;

        public void OnSpawned(IMemoryPool pool)
        {
            m_pool = pool;
        }

        public void OnDespawned()
        {
            m_pool = null;
        }

        public void AddCell(AchievementCellView achievementCell)
        {
            achievementCell.transform.SetParent(transform, false);
        }

        public void Clear()
        {
            m_pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<AchievementsGroupView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<IMemoryPool, AchievementsGroupView>
        {
        }
    }
}