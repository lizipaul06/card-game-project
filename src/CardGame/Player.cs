namespace CardCame
{
    public class Player : Person
    {
        public void SetPlayerName()
        {
            Console.WriteLine("\r\n");
            Console.Write("\r\n" + "Please enter player's name: ");
            string? playerName = Console.ReadLine();


            while (playerName == "")
            {
                Console.WriteLine("Players name cannot be empty...");
                Console.Write("\r\n" + "Please enter player's name: ");
                playerName = Console.ReadLine();

            }
            if (playerName != null) name = playerName;
            Console.Write("\r\n" + "Welcome " + playerName);

        }

        public decimal Funds { get; set; } = 200M; //$200
        public decimal Bet { get; set; }

        public decimal InsuranceBet { get; set; }
        public bool HasInsurance => InsuranceBet > 0M;
        public decimal Change { get; set; }
        public bool HasStood { get; set; }
        public void Collect()
        {
            Funds += Change;
            Change = 0M;
            InsuranceBet = 0M;
        }
    }
}