using System;
using System.Collections.Generic;

namespace deck
{
	class Card
	{
		public string stringVal;
		public string suit;
		public int val;
		public Card(string StringVal, string Suit, int Val)
		{
			stringVal = StringVal;
			suit = Suit;
			val = Val;
		}
	}
	class Deck{
		public List<Card> cards;
		public List<string> stringVal = new List<string>() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
		public List<string> suit = new List<string>() {"Clubs", "Spades", "Hearts", "Diamonds"};
		public List<int> val = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

		public Deck(){
			makeDeck();
		}

		public void makeDeck(){
			cards = new List<Card>();
			for(int i=0; i<suit.Count; i++){
				for(int k=0; k<stringVal.Count; k++){
					cards.Add(new Card(stringVal[k], suit[i], val[k]));
				}
			}
		}
		public void displayDeck(){
			foreach (var deal in cards){
				Console.WriteLine(deal.stringVal + " " + deal.suit + " " + deal.val);
			}
		}
		public Card dealCard(){
			var pop = cards[cards.Count-1];
			cards.Remove(cards[cards.Count-1]);
			return pop;
		}
		
		public void shuffle(){
			Random rand = new Random();
			int s = cards.Count;
			while (s > 1){
				s--;
				Card temp = cards[s];
				int k = rand.Next(s + 1);
				cards[s] = cards[k];
				cards[k] = temp;
			}
		}
	}
    class Program
    {
        static void Main(string[] args)
        {
        	Deck d = new Deck();
        	d.makeDeck();
            d.shuffle();
            var rem = d.dealCard();
            Console.WriteLine($"Removed value: {rem.stringVal} of {rem.suit}");
            d.displayDeck();
        }
    }
}
