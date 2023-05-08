﻿using UnityEngine;

namespace Match3
{
    public class LevelMoves : Level
    {

        public DataSender _sender;
        [HideInInspector] public float _timer;
        public int numMoves;
        public int targetScore;
        private int _movesUsed = 0;

        private void Start()
        {
            type = LevelType.Moves;

            hud.SetLevelType(type);
            hud.SetScore(currentScore);
            hud.SetTarget(targetScore);
            hud.SetRemaining(numMoves);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        public override void OnMove()
        {
            _movesUsed++;

            hud.SetRemaining(numMoves - _movesUsed);

            if (numMoves - _movesUsed != 0) return;
        
            if (currentScore >= targetScore)
            {
                GameWin();
                _sender.Send(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Win", $"{_movesUsed}",
                $"{numMoves}", $"{_timer}", $"0", $"0", $"0", $"{horisontalBonus}", $"{verticalBonus}",
                $"{rainbowBonus}", $"{currentScore}", $"{currentScore/10}", $"{hud._starIndex}");
            }
            else
            {
                GameLose();
                _sender.Send(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, "Lose", $"{_movesUsed}",
                $"{numMoves}", $"{_timer}", $"0", $"0", $"0", $"{horisontalBonus}", $"{verticalBonus}",
                $"{rainbowBonus}", $"{currentScore}", $"0", $"0");
            }
        }
    }
}
