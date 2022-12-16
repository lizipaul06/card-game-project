namespace CardCame
{
    public class Dealer : Person
    {

        public Card Deal(CardDeck deck)
        {

            return deck.Draw();
        }

        public void DealToSelf(CardDeck deck)
        {
            Card drawnCard = Deal(deck);
            AddCard(drawnCard);

        }

        public void DealToPlayer(Player player, CardDeck deck)
        {
            Card drawnCard = Deal(deck);

            player.AddCard(drawnCard);


        }
        public bool HasAceShowing()
        {
            if (Cards.Count == 2 && Score == 11)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
    }



}