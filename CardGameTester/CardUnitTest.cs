using CardGame;

namespace CardGameTester
{
    [TestClass]
    public class CardUnitTest
    {
        [TestMethod]
        public void CardConstructor_CorrectRankSuit()
        {
            Card card = new Card(Rank.Ace, Suit.Hearts);
            Enum expRank, expSuit, actRank, actSuit;

            expRank = Rank.Ace;
            expSuit = Suit.Hearts;

            actRank = card.Rank;
            actSuit = card.Suit;

            Assert.AreEqual(expRank, actRank);
            Assert.AreEqual(expSuit, actSuit);
        }

        [TestMethod]
        public void FlipOver_FaceUp_Valid()
        {
            Card card = new Card(Rank.Ace, Suit.Hearts);
            Assert.IsFalse(card.FaceUp);
            card.FlipOver();
            Assert.IsTrue(card.FaceUp);
        }
    }
}