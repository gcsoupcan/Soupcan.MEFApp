using System;
using Xunit;

namespace Soupcan.Crawler.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void PlayerStartsAtBeginning()
        {
            Player player = new Player();
            CheckPlayerIsAt(player, 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void PlayerStartsWhereSpecificed(int startingLocation)
        {
            Player player = new Player(startingLocation);
            CheckPlayerIsAt(player, startingLocation);
        }

        [Fact]
        public void PlayerMoves()
        {
            Player player = new Player();

            player.Move();

            CheckPlayerIsAt(player, 1);
        }        

        [Fact]
        public void PlayerGoesBackward()
        {
            Player player = new Player(2);

            player.MoveBack();

            CheckPlayerIsAt(player, 1);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void PlayerCannotMoveTooFarBack(int startingLocation)
        {
            Player player = new Player(startingLocation);

            player.MoveBack();
            player.MoveBack();
            CheckPlayerIsAt(player, 0);
        }

        private void CheckPlayerIsAt(Player player, int location)
        {
            Assert.Equal(player.Location, location);
        }
    }
}
