using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sudoku.Test {

    [TestFixture]
    public class BoardTests {

        [TestCase(0, 0, 0, '5')]
        [TestCase(0, 0, 1, '3')]
        [TestCase(0, 0, 2, ' ')]
        [TestCase(0, 1, 0, '6')]
        [TestCase(0, 1, 1, ' ')]
        [TestCase(0, 1, 2, ' ')]
        [TestCase(0, 2, 0, ' ')]
        [TestCase(0, 2, 1, '9')]
        [TestCase(0, 2, 2, '8')]
        [TestCase(2, 2, 1, '6')]
        [TestCase(4, 0, 1, '6')]
        [TestCase(4, 2, 1, '2')]
        [TestCase(8, 2, 2, '9')]
        public void Kann_Felder_abrufen(int boardNumber, int row, int column, char expected) {
            var board = new Board();
            var value = board.Get(boardNumber, row, column);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void Kann_Felder_setzen() {
            var board = new Board();

            for (int b = 0; b < 9; b++) {
                for (int row = 0; row < 3; row++) {
                    for (int col = 0; col < 3; col++) {
                        board.Set(b, row, col, '1');
                        Assert.AreEqual('1', board.Get(b, row, col));
                        board.Set(b, row, col, '2');
                        Assert.AreEqual('2', board.Get(b, row, col));
                    }
                }
            }
        }

        [TestCase(0, 0, 0, '5', true)]
        [TestCase(0, 2, 0, '1', true)]
        [TestCase(0, 2, 0, '3', false)]
        [TestCase(4, 0, 0, '6', false)]
        [TestCase(4, 1, 1, '6', false)]
        [TestCase(4, 1, 2, '6', false)]
        public void Ist_gültig(int boardNumber, int row, int column, char value, bool expected) {
            var board = new Board();
            board.Set(boardNumber, row, column, value);

            Assert.AreEqual(expected, board.CheckValid());
        }
    }
}
