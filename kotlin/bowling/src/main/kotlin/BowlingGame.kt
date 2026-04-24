class BowlingGame {
    private val rolls = mutableListOf<Int>()

    fun roll(pins: Int) {
        if (pins !in 0..10) throw IllegalStateException("Pins must be between 0 and 10")
        if (isFinished()) throw IllegalStateException("Cannot roll after game is finished")

        val frameInfo = getCurrentFrameInfo()
        if (frameInfo.frameNumber < 10 && frameInfo.isSecondBall) {
            if (rolls.last() + pins > 10) {
                throw IllegalStateException("Two rolls in a frame cannot exceed 10 pins")
            }
        }

        if (frameInfo.frameNumber == 10) {
            validateTenthFrame(frameInfo.ballIndexInFrame, pins)
        }

        rolls.add(pins)
    }

    fun score(): Int {
        if (!isFinished()) throw IllegalStateException("Cannot score an incomplete game")

        var totalScore = 0
        var rollIndex = 0

        for (frame in 1..10) {
            when {
                isStrike(rollIndex) -> {
                    totalScore += 10 + strikeBonus(rollIndex)
                    rollIndex += 1
                }

                isSpare(rollIndex) -> {
                    totalScore += 10 + spareBonus(rollIndex)
                    rollIndex += 2
                }

                else -> {
                    totalScore += rolls[rollIndex] + rolls[rollIndex + 1]
                    rollIndex += 2
                }
            }
        }
        return totalScore
    }

    private fun isStrike(index: Int) = rolls[index] == 10
    private fun isSpare(index: Int) = rolls[index] + rolls[index + 1] == 10
    private fun strikeBonus(index: Int) = rolls[index + 1] + rolls[index + 2]
    private fun spareBonus(index: Int) = rolls[index + 2]

    private fun validateTenthFrame(ballIndex: Int, pins: Int) {
        if (ballIndex == 1) { // Second ball of 10th frame
            val firstBall = rolls.last()
            if (firstBall < 10 && firstBall + pins > 10) {
                throw IllegalStateException("Invalid pin count in 10th frame")
            }
        } else if (ballIndex == 2) { // Third ball (bonus ball)
            val firstBall = rolls[rolls.size - 2]
            val secondBall = rolls.last()

            if (firstBall == 10 && secondBall < 10 && secondBall + pins > 10) {
                throw IllegalStateException("Invalid bonus roll after strike")
            }
        }
    }

    private fun isFinished(): Boolean {
        var rollIndex = 0
        for (frame in 1..10) {
            if (rollIndex >= rolls.size) return false
            if (isStrike(rollIndex)) {
                if (frame == 10) return rolls.size == rollIndex + 3
                rollIndex += 1
            } else {
                if (rollIndex + 1 >= rolls.size) return false
                if (isSpare(rollIndex)) {
                    if (frame == 10) return rolls.size == rollIndex + 3
                } else if (frame == 10) {
                    return rolls.size == rollIndex + 2
                }
                rollIndex += 2
            }
        }
        return true
    }

    private data class FrameInfo(val frameNumber: Int, val isSecondBall: Boolean, val ballIndexInFrame: Int)

    private fun getCurrentFrameInfo(): FrameInfo {
        var rollIndex = 0
        for (frame in 1..10) {
            val ballsLeftInThisFrame = if (rollIndex < rolls.size) {
                if (isStrike(rollIndex) && frame < 10) 1 else 2
            } else 2

            val ballsInCurrent = rolls.size - rollIndex
            if (ballsInCurrent < ballsLeftInThisFrame || frame == 10) {
                return FrameInfo(frame, ballsInCurrent == 1, ballsInCurrent)
            }
            rollIndex += ballsLeftInThisFrame
        }
        return FrameInfo(11, false, 0)
    }
}