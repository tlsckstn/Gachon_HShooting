using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 플레이어 종류에 따라 Stat을 UI로 표시
/// </summary>
public class LobbyPlayerUI : MonoBehaviour
{
    [SerializeField] private StatSO stat;
    [SerializeField] private int playerIndex = 0;
    [SerializeField] private TMP_Text statText;
    [SerializeField] private Button selectButton;

    private void Awake()
    {
        statText.text =
            $"HP: {stat.HPStat.BaseValue}\n" +
            $"Damage: {stat.DamageStat.Value}\n" +
            $"Speed: {stat.SpeedStat.Value}\n";
        selectButton.onClick.AddListener(() => GameManager.Instance.SelectPlayerIndex(playerIndex));
    }
}