using System.Collections.Immutable;
using System.Reactive;
using System.Reactive.Subjects;

public class HangmanState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public HangmanState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

public class TooManyGuessesException : Exception
{
}

public class Hangman
{
    private readonly string word;
    private readonly Subject<char> guesses = new();
    private readonly BehaviorSubject<HangmanState> states;

    public IObservable<HangmanState> StateObservable => states;
    public IObserver<char> GuessObserver => Observer.Create<char>(guess =>
    {
        var current = states.Value;

        if (current.RemainingGuesses <= 0)
        {
            states.OnError(new TooManyGuessesException());
            return;
        }

        var alreadyGuessed = current.GuessedChars.Contains(guess);
        var guessed = current.GuessedChars.Add(guess);
        var correct = !alreadyGuessed && word.Contains(guess);
        var masked = new string([.. word.Select(c => guessed.Contains(c) ? c : '_')]);
        var remaining = correct ? current.RemainingGuesses : current.RemainingGuesses - 1;


        if (masked == word)
        {
            states.OnCompleted();
        }
        else
        {
            var next = new HangmanState(masked, guessed, remaining);

            states.OnNext(next);
        }
    });

    public Hangman(string word)
    {
        this.word = word;

        var initial = new string('_', word.Length);

        states = new BehaviorSubject<HangmanState>(new HangmanState(initial, [], 9));
    }
}
