using TMPro;
using UnityEngine;
using UnityEngine.UI;

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