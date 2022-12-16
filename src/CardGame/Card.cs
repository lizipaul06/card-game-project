namespace CardCame;

public enum CardValue
{
    Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
}


public enum CardSuit
{
    Hearts = 1,
    Spades = 2,
    Clubs = 3,
    Diamonds = 4
}

public class Card
{
    public CardValue Value { get; set; }
    public CardSuit Suit { get; set; }

    public bool IsVisible { get; set; } = true;

    public bool IsTenCard
    {
        get
        {
            return Value == CardValue.Ten || Value == CardValue.Jack || Value == CardValue.Queen || Value == CardValue.King;
        }
    }

    public int Score
    {
        get
        {
            if (IsTenCard)
            {
                return 10;
            }
            if (Value == CardValue.Ace)
            {
                return 11;
            }
            else
            {
                return (int)Value;
            }
        }
    }
}
