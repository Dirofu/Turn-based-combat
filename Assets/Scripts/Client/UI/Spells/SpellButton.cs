using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    [RequireComponent(typeof(Button))]
    public class SpellButton : MonoBehaviour
    {
        [SerializeField] private Spell _spell;

        private Button _button;
        private CooldownTimer _cooldownTimer;
        private SpellAnnouncer _announcer;

        private void OnEnable()
        {
            _cooldownTimer.CooldownEnded += CloseCooldownTimer;
        }

        private void OnDisable()
        {
            _cooldownTimer.CooldownEnded -= CloseCooldownTimer;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _announcer = GetComponentInParent<SpellAnnouncer>();
            _cooldownTimer = GetComponentInChildren<CooldownTimer>();
            _cooldownTimer.gameObject.SetActive(false);
        }

        public void UseSpell()
        {
            _announcer.UseSpell(_spell);
            OpenCooldownTimer();
        }

        private void OpenCooldownTimer()
        {
            _cooldownTimer.gameObject.SetActive(true);
            _cooldownTimer.Initialize(_spell.Cooldown);
        }

        private void CloseCooldownTimer()
        {
            _cooldownTimer.gameObject.SetActive(false);
            _button.interactable = true;
        }
    }
}