using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _value;

    private Character _character;
    private Transform _target;

    private void OnEnable()
    {
        if (_character != null)
            _character.HealthChanged += ShowNewValue;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= ShowNewValue;
    }

    private void Update()
    {
        if (transform.position != _target.position)
            transform.position = _target.position;
    }

    public void Initialize(Character character, Transform target)
    {
        _character = character;
        _target = target;
        OnEnable();
    }

    private void ShowNewValue()
    {
        _slider.value = _character.CurrentHealth / _character.MaxHealth;
        _value.text = _character.CurrentHealth.ToString();
    }
}
