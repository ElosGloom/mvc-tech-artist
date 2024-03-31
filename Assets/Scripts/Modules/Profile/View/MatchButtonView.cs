using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public struct MatchButtonProtocol
{
    public string MatchType;
    public Sprite Icon;
}

public class MatchButtonView : MonoBehaviour, IPoolable<MatchButtonProtocol, IMemoryPool>
{
    [SerializeField] private TextMeshProUGUI m_matchType;
    [SerializeField] private Image m_icon;
    [SerializeField] private Button m_matchButton;
    
    
    
    private IMemoryPool _pool;

    public Button.ButtonClickedEvent ButtonClickEvent => m_matchButton.onClick;

    public void OnSpawned(MatchButtonProtocol protocol, IMemoryPool pool)
    {
        _pool = pool;
        m_matchType.text = protocol.MatchType;
        m_icon.sprite = protocol.Icon;
    }

    public void OnDespawned()
    {
        _pool = null;
    }

    
    public class Factory : PlaceholderFactory<MatchButtonProtocol, MatchButtonView>
    {
    }

    public class Pool : MonoPoolableMemoryPool<MatchButtonProtocol, IMemoryPool, MatchButtonView>
    {
    }
    
}
