public class BowlingGame
{
    private readonly List<int> rolls = [];

    public void Roll(int pins)
    {
        if (pins < 0 || pins > 10) throw new ArgumentException("Pins must be between 0 and 10");
        if (IsFinished()) throw new ArgumentException("Cannot roll after game is finished");

        var frameInfo = GetCurrentFrameInfo();

        if (frameInfo.frameNumber < 10 && frameInfo.isSecondBall)
        {
            if (rolls.Last() + pins > 10)
            {
                throw new ArgumentException("Two rolls in a frame cannot exceed 10 pins");
            }
        }

        if (frameInfo.frameNumber == 10)
        {
            ValidateTenthFrame(frameInfo.ballIndexInFrame, pins);
        }

        rolls.Add(pins);
    }

    public int? Score()
    {
        if (!IsFinished()) throw new ArgumentException("Cannot score an incomplete game");

        var totalScore = 0;
        var rollIndex = 0;

        for (var frame = 1; frame <= 10; frame++)
        {
            if (IsStrike(rollIndex))
            {
                totalScore += 10 + StrikeBonus(rollIndex);
                rollIndex += 1;
            }
            else if (IsSpare(rollIndex))
            {
                totalScore += 10 + SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else
            {
                totalScore += rolls[rollIndex] + rolls[rollIndex + 1];
                rollIndex += 2;
            }
        }

        return totalScore;
    }

    private bool IsStrike(int index) => rolls[index] == 10;
    private bool IsSpare(int index) => rolls[index] + rolls[index + 1] == 10;
    private int StrikeBonus(int index) => rolls[index + 1] + rolls[index + 2];
    private int SpareBonus(int index) => rolls[index + 2];

    private void ValidateTenthFrame(int ballIndex, int pins)
    {
        if (ballIndex == 1)
        {
            var firstBall = rolls.Last();
            if (firstBall < 10 && firstBall + pins > 10)
            {
                throw new ArgumentException("Invalid pin count in 10th frame");
            }
        }
        else if (ballIndex == 2)
        {
            var firstBall = rolls[rolls.Count - 2];
            var secondBall = rolls.Last();

            if (firstBall == 10 && secondBall < 10 && secondBall + pins > 10)
            {
                throw new ArgumentException("Invalid bonus roll after strike");
            }
        }
    }

    private bool IsFinished()
    {
        var rollIndex = 0;

        for (var frame = 1; frame <= 10; frame++)
        {
            if (rollIndex >= rolls.Count) return false;

            if (IsStrike(rollIndex))
            {
                if (frame == 10) return rolls.Count == rollIndex + 3;
                rollIndex += 1;
            }
            else
            {
                if (rollIndex + 1 >= rolls.Count) return false;

                if (IsSpare(rollIndex))
                {
                    if (frame == 10) return rolls.Count == rollIndex + 3;
                }
                else if (frame == 10)
                {
                    return rolls.Count == rollIndex + 2;
                }
                rollIndex += 2;
            }
        }

        return true;
    }

    private (int frameNumber, bool isSecondBall, int ballIndexInFrame) GetCurrentFrameInfo()
    {
        var rollIndex = 0;

        for (var frame = 1; frame <= 10; frame++)
        {
            var ballLeftInThisFrame = rollIndex < rolls.Count
                ? IsStrike(rollIndex) && frame < 10
                    ? 1
                    : 2
                : 2;

            var ballsInCurrent = rolls.Count - rollIndex;

            if (ballsInCurrent < ballLeftInThisFrame || frame == 10)
            {
                return (frame, ballsInCurrent == 1, ballsInCurrent);
            }

            rollIndex += ballLeftInThisFrame;
        }

        return (11, false, 0);
    }
}