using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.Profile.View
{
    public struct AchievementCellProtocol
    {
        public string AchievementName;
        public string Date;
        public Sprite Icon;
    }

    public class AchievementCellView : MonoBehaviour, IPoolable<AchievementCellProtocol, IMemoryPool>, IClearable
    {
        [SerializeField] private TextMeshProUGUI m_name;
        [SerializeField] private TextMeshProUGUI m_date;
        [SerializeField] private Image m_icon;

        private IMemoryPool m_pool;


        public void OnSpawned(AchievementCellProtocol protocol, IMemoryPool pool)
        {
            m_pool = pool;
            m_name.text = protocol.AchievementName;
            m_date.text = protocol.Date;
            
            if (protocol.Icon == null)
                return;
            
            m_icon.sprite = protocol.Icon;
        }

        public void OnDespawned()
        {
            m_pool = null;
        }

        public class Factory : PlaceholderFactory<AchievementCellProtocol, AchievementCellView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<AchievementCellProtocol, IMemoryPool, AchievementCellView>
        {
        }

        public void Clear()
        {
            m_pool.Despawn(this);
        }
    }
}