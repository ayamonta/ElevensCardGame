using CardGame;

namespace CardGameTester
{
    [TestClass]
    public class DeckUnitTest
    {
        [TestMethod]
        public void DeckConstructor_Initialize_ExpectedNumCard()
        {
            // Arrange
            int expectTotal = 52;
            Deck deck = new Deck();

            // Act

            // Assert
            int actualTotal = deck.NumCards;
            Assert.AreEqual(expectTotal, actualTotal);
        }

        [TestMethod]
        public void ExpectedSuitRank()
        {
            // Arrange
            int expectRanks = 13;
            int expectSuits = 4;

            // Act

            // Assert
            int[] actualRanks = (int[])Enum.GetValues(typeof(Rank));
            int[] actualSuits = (int[])Enum.GetValues(typeof(Suit));
            Assert.AreEqual(expectRanks, actualRanks.Length);
            Assert.AreEqual(expectSuits, actualSuits.Length);
        }

        [TestMethod]
        public void CutMethod_SplitReassembleValid()
        {
            // Arrange
            Deck deck = new Deck();
            Card firstExpc, locMinusExpc, locExpc, lastExpc;
            int total = 51;
            int loc = 10;

            // Act
            firstExpc = deck.RetrieveValue(0);
            locMinusExpc = deck.RetrieveValue(loc - 1);
            locExpc = deck.RetrieveValue(loc);
            lastExpc = deck.RetrieveValue(total);

            deck.Cut(10);

            // Assert
            Card firstAct, locMinusAct, locAct, lastAct;

            firstAct = deck.RetrieveValue(total - loc + 1);
            locMinusAct = deck.RetrieveValue(total);
            locAct = deck.RetrieveValue(0);
            lastAct = deck.RetrieveValue(total - loc);

            Assert.AreEqual(firstExpc.Rank, firstAct.Rank);
            Assert.AreEqual(firstExpc.Suit, firstAct.Suit);

            Assert.AreEqual(locMinusExpc.Rank, locMinusAct.Rank);
            Assert.AreEqual(locMinusExpc.Suit, locMinusAct.Suit);

            Assert.AreEqual(locExpc.Rank, locAct.Rank);
            Assert.AreEqual(locExpc.Suit, locAct.Suit);

            Assert.AreEqual(lastExpc.Rank, lastAct.Rank);
            Assert.AreEqual(lastExpc.Suit, lastAct.Suit);
        }

        [TestMethod]
        public void CutMethod_AtFirstCard()
        {
            Deck deck = new Deck();
            Card firstExp = deck.RetrieveValue(0);
            deck.Cut(0);
            Card firstAct = deck.RetrieveValue(0);
            Assert.AreEqual(firstExp, firstAct);
        }

        [TestMethod]
        public void CutMethod_AtLastCard()
        {
            Deck deck = new Deck();
            Card firstExp = deck.RetrieveValue(51);
            deck.Cut(51);
            Card firstAct = deck.RetrieveValue(51);
            Assert.AreEqual(firstExp, firstAct);
        }

        [TestMethod]
        public void Shuffle_DiffLocation()
        {
            Random rand = new Random();
            Deck deck = new Deck();
            Deck deck2 = new Deck();
            int size = 3;
            int max = 51;
            int[] randNum = new int[size];
            Card[] exp = new Card[size];
            Card[] act = new Card[size];

            for (int i = 0; i < size; ++i)
            {
                randNum[i] = rand.Next(0, max - i);
                exp[i] = deck.RetrieveValue(randNum[i]);
                deck.RemoveCard(randNum[i]);
            }

            deck2.Shuffle();

            for (int i = 0; i < size; ++i)
            {
                act[i] = deck2.RetrieveValue(randNum[i]);
            }

            for (int i = 0; i < size; ++i)
            {
                Assert.AreNotEqual(exp[i], act[i]);
            }
        }

        [TestMethod]
        public void TakeTopCard_ReturnCorrectCard()
        {
            Deck deck = new Deck();
            int total = 51;
            int actTotal;
            Card expCard, actCard;

            expCard = deck.RetrieveValue(total);

            actCard = deck.TakeTopCard();
            actTotal = deck.NumCards;
            Assert.AreEqual(expCard, actCard);
            Assert.AreEqual(total, actTotal);
        }

        [TestMethod]
        public void TakeTopCard_EmptyDeck_ReturnNull()
        {
            Deck deck = new Deck();
            Card card;
            int total = 52;

            for (int i = 0; i < total; ++i)
            {
                card = deck.TakeTopCard();
            }

            Assert.IsNull(deck.TakeTopCard());
        }
    }
}