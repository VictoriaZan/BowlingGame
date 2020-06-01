namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int result = 0;
            int currentIndex = 0;
            const int bonus = 10;

            for (int f = 0; f < 10; f++)
            {
                if (rolls[currentIndex] == 10)
                {
                    result += bonus + rolls[currentIndex + 1] + rolls[currentIndex + 2];
                    currentIndex = currentIndex+1;
                }
                else
                {
                    if (rolls[currentIndex] + rolls[currentIndex + 1] == 10)
                    {
                        result += bonus + rolls[currentIndex + 2];
                    }
                    else
                    {
                        result += rolls[currentIndex] + rolls[currentIndex + 1];
                    }

                    currentIndex = currentIndex + 2;
                }
            }

            return result;
        }
    }
}
