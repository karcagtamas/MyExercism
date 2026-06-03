using System;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }

    public record GameResult(GameStatus Status, int Tricks, int Cards);

    private static readonly Dictionary<string, int> PenaltyMap = new()
    {
        { "J", 1 },
        { "Q", 2 },
        { "K", 3 },
        { "A", 4 }
    };

    public static GameResult SimulateGame(string[] playerA, string[] playerB)
    {
        var deckA = new Queue<string>(playerA);
        var deckB = new Queue<string>(playerB);
        var pile = new List<string>();

        var seenStates = new HashSet<string>();

        int trickCount = 0;
        int cardPlayedCount = 0;

        var currentPlayer = deckA;
        var opponent = deckB;

        while (true)
        {
            string stateSnapshot = GetStateSnapshot(deckA, deckB, pile, currentPlayer == deckA);
            if (!seenStates.Add(stateSnapshot))
            {
                return new GameResult(GameStatus.Loop, trickCount, cardPlayedCount);
            }

            if (pile.Count == 0 || !PenaltyMap.ContainsKey(pile[^1]))
            {
                if (currentPlayer.Count == 0)
                {
                    CollectPile(opponent, pile, ref trickCount);
                    break;
                }

                string playedCard = currentPlayer.Dequeue();
                pile.Add(playedCard);
                cardPlayedCount++;

                if (!PenaltyMap.ContainsKey(playedCard))
                {
                    (currentPlayer, opponent) = (opponent, currentPlayer);
                }
            }
            else
            {
                string activePenaltyCard = pile[^1];
                int cardsOwed = PenaltyMap[activePenaltyCard];
                bool penaltyInterrupted = false;

                for (int i = 0; i < cardsOwed; i++)
                {
                    if (opponent.Count == 0)
                    {
                        break;
                    }

                    string playedCard = opponent.Dequeue();
                    pile.Add(playedCard);
                    cardPlayedCount++;

                    if (PenaltyMap.ContainsKey(playedCard))
                    {
                        penaltyInterrupted = true;
                        break;
                    }
                }

                if (penaltyInterrupted)
                {
                    (currentPlayer, opponent) = (opponent, currentPlayer);
                }
                else
                {
                    CollectPile(currentPlayer, pile, ref trickCount);

                    if (deckA.Count == 0 || deckB.Count == 0)
                    {
                        break;
                    }
                }
            }
        }

        return new GameResult(GameStatus.Finished, trickCount, cardPlayedCount);
    }

    private static void CollectPile(Queue<string> winnerDeck, List<string> pile, ref int trickCount)
    {
        if (pile.Count > 0)
        {
            foreach (var card in pile)
            {
                winnerDeck.Enqueue(card);
            }
            pile.Clear();
            trickCount++;
        }
    }

    private static string GetStateSnapshot(Queue<string> a, Queue<string> b, List<string> pile, bool isATurn)
    {
        var maskedA = a.Select(c => PenaltyMap.ContainsKey(c) ? c : "-");
        var maskedB = b.Select(c => PenaltyMap.ContainsKey(c) ? c : "-");
        var maskedPile = pile.Select(c => PenaltyMap.ContainsKey(c) ? c : "-");

        return $"{string.Join(",", maskedA)}|{string.Join(",", maskedB)}|{string.Join(",", maskedPile)}|{isATurn}";
    }
}
