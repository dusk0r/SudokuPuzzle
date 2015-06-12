using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku {

	public class Board {
        private char[,] board = new char[9, 9] {
			{'5', '3', ' ', ' ', '7', ' ', ' ', ' ', ' '},
			{'6', ' ', ' ', '1', '9', '5', ' ', ' ', ' '},
			{' ', '9', '8', ' ', ' ', ' ', ' ', '6', ' '},
			{'8', ' ', ' ', ' ', '6', ' ', ' ', ' ', '3'},
			{'4', ' ', ' ', '8', ' ', '3', ' ', ' ', '1'},
			{'7', ' ', ' ', ' ', '2', ' ', ' ', ' ', '6'},
			{' ', '6', ' ', ' ', ' ', ' ', '2', '8', ' '},
			{' ', ' ', ' ', '4', '1', '9', ' ', ' ', '5'},
			{' ', ' ', ' ', ' ', '8', ' ', ' ', '7', '9'},
		};

        public void Set(int boardNumber, int row, int column, char value) {
            var realIndex = GetRealIndex(boardNumber, row, column);

            board[realIndex.Item1, realIndex.Item2] = value;
        }

        public char Get(int boardNumber, int row, int column) {
            var realIndex = GetRealIndex(boardNumber, row, column);

            return board[realIndex.Item1, realIndex.Item2];
        }

        /// <summary>
        /// Prüft alle 3x3 Felder
        /// </summary>
        private bool CheckBoard(int boardNumber) {

        }

        /// <summary>
        /// Prüft alle Reihen
        /// </summary>
        private bool CheckRows() {

        }

        /// <summary>
        /// Prüft alle Spalten
        /// </summary>
        private bool CheckColumns() {

        }

        /// <summary>
        /// Prüft ob Zahlen zwischen 1 und 9 korrekt sind
        /// </summary>
        /// <returns></returns>
        private bool CheckNumbers() {

        }

        private Tuple<int, int> GetRealIndex(int boardNumber, int row, int column) {
            var realRow = (boardNumber / 3) * 3 + row;
            var realColumn = (boardNumber % 3) * 3 + column;
            return Tuple.Create(realRow, realColumn);
        }

	}
}
