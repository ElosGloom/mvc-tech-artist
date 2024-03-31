using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Modules.Profile.View
{
    public struct MatchButtonProtocol
    {
        public string MatchType;
        public Sprite Icon;
    }

    public class MatchButtonView : MonoBehaviour, IPoolable<MatchButtonProtocol, IMemoryPool>, IClearable
    {
        [SerializeField] private TextMeshProUGUI m_matchType;
        [SerializeField] private Image m_icon;
        [SerializeField] private Button m_matchButton;

        private IMemoryPool m_pool;

        public Button.ButtonClickedEvent ButtonClickEvent => m_matchButton.onClick;

        public void OnSpawned(MatchButtonProtocol protocol, IMemoryPool pool)
        {
            m_pool = pool;
            m_matchType.text = protocol.MatchType;
            m_icon.sprite = protocol.Icon;
        }

        public void OnDespawned()
        {
            m_pool = null;
        }

        public void Clear()
        {
            m_pool.Despawn(this);
        }
    
        public class Factory : PlaceholderFactory<MatchButtonProtocol, MatchButtonView>
        {
        }

        public class Pool : MonoPoolableMemoryPool<MatchButtonProtocol, IMemoryPool, MatchButtonView>
        {
        }
    }
}