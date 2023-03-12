namespace SnakeRunner.Gameplay.Obstacle
{
    using System;
    using Unit.Death;
    using UnityEngine;

    [RequireComponent(typeof(UnitDeathTrigger))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField]
        private UnitDeathTrigger trigger;

        private void OnValidate()
        {
            trigger = GetComponent<UnitDeathTrigger>();
        }

        private void Awake()
        {
            trigger.OnEnter += KillPlayer;
        }

        private void KillPlayer(UnitDeath unitDeath)
        {
            gameObject.SetActive(false);
            unitDeath.Kill();
        }

        private void OnDestroy()
        {
            trigger.OnEnter -= KillPlayer;
        }
    }
}