namespace CardCame;
public class CardDeck
{
    public List<Card> Cards { get; set; } = new List<Card>();

    public int Count
    {
        get
        {
            return Cards.Count;
        }
    }

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    public Card Draw()
    {
        var card = this.Cards.First<Card>();
        this.Cards.Remove(card);
        return card;
    }


    public void ShuffleDeck(List<Card> cards)
    {


        Random rnd = new Random();

        for (int n = cards.Count() - 1; n > 0; --n)
        {
            int k = rnd.Next(n + 1);

            Card temp = cards[n];
            cards[n] = cards[k];
            cards[k] = temp;
        }

        for (int n = 0; n < cards.Count(); n++)
        {
            this.Cards.Add(cards[n]);
        }
        this.Cards = cards;
    }
    public void BuildCardDeck()
    {
        List<Card> cards = new List<Card>();

        foreach (CardSuit suit
           in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
        {
            foreach (CardValue value in (CardValue[])Enum.GetValues(typeof(CardValue)))
            {
                Card newCard = new Card()
                {
                    Suit = suit,
                    Value = value
                };
                cards.Add(newCard);
            }

        }

        ShuffleDeck(cards);



    }

}
