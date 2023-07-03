using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _value;

    [Header("Bar Settings")]
    [SerializeField] private Image _bar;
    [SerializeField] private Sprite _playerBar;
    [SerializeField] private Sprite _enemyBar;

    private Character _character;

    private void OnEnable()
    {
        if (_character != null)
            _character.HealthChanged += ShowNewValue;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= ShowNewValue;
    }

    public void Initialize(Character character, bool isPlayer)
    {
        _character = character;
        OnEnable();
        ShowNewValue();

        _bar.sprite = isPlayer ? _playerBar : _enemyBar;
    }

    private void ShowNewValue()
    {
        _slider.value = _character.CurrentHealth / _character.MaxHealth;
        _value.text = _character.CurrentHealth.ToString();
    }
}
