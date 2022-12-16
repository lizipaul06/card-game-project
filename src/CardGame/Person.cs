namespace CardCame
{
    public class Person
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public string name { get; set; } = "";


        private int ScoreCalculation()
        {
            var cards = this.Cards;
     

            var totalScore = cards.Sum(x => x.Score);
            if (totalScore <= 21) return totalScore;

            bool hasAces = cards.Any(x => x.Value == CardValue.Ace);
            if (!hasAces && totalScore > 21) return totalScore;

            var acesCount = cards.Where(x => x.Value == CardValue.Ace).Count();
            var acesScore = cards.Sum(x => x.Score);

            while (acesCount > 0)
            {
                acesCount -= 1;
                acesScore -= 10;
                if (acesScore <= 21) return acesScore;
            }

            return cards.Sum(x => x.Score);
        }
        public int Score
        {
            get
            {
                return ScoreCalculation();
            }
        }

    

        public bool HasNaturalBlackjack =>
        this.Cards.Count == 2
        && Score == 21
        && this.Cards.Any(x => x.Value == CardValue.Ace)
        && this.Cards.Any(X => X.IsTenCard);

        public bool IsBusted => Score > 21;

        public string ScoreDisplay
        {
            get
            {
                if (HasNaturalBlackjack ){
                    return "Blackjack!";
                }
                if (Score > 21){
                    return "Busted!";
                }
                else return Score.ToString();
            }
        }
        public void AddCard(Card card){
    
            this.Cards.Add(card);

            Task.Delay(300).Wait();
  
        }

        public void ClearHand()
        {
            this.Cards.Clear();
        }
    }
}