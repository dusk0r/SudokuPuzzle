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

        public bool CheckValid() {
            return CheckBoards() && CheckRows() && CheckColumns();
        }

        /// <summary>
        /// Prüft alle 3x3 Felder
        /// </summary>
        private bool CheckBoards() {
            // Alle 9 Boards prüfen
            for (int i = 0; i < 9; i++) {
                int startRow = (i / 3) * 3;
                int startColumn = (i % 3) * 3;

                if (!CheckNumbers(startRow, startColumn, startRow + 2, startColumn + 2)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft alle Reihen
        /// </summary>
        private bool CheckRows() {
            for (int i = 0; i < 9; i++) {
                if (!CheckNumbers(i, 0, i, 8)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft alle Spalten
        /// </summary>
        private bool CheckColumns() {
            for (int i = 0; i < 9; i++) {
                if (!CheckNumbers(0, i, 8, i)) {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Prüft ob Zahlen zwischen 1 und 9 maximal einmal vorkommen
        /// </summary>
        /// <returns></returns>
        private bool CheckNumbers(int startRow, int startColumn, int endRow, int endColumn) {
            var set = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int row = startRow; row <= endRow; row++) {
                for (int column = startColumn; column <= endColumn; column++) {
                    var c = board[row, column];

                    if (c == ' ') {

                    } else if (set.Contains(c)) {
                        set.Remove(c);
                    } else {
                        return false;
                    }
                }
            }
            
            return true;
        }

        private Tuple<int, int> GetRealIndex(int boardNumber, int row, int column) {
            var realRow = (boardNumber / 3) * 3 + row;
            var realColumn = (boardNumber % 3) * 3 + column;
            return Tuple.Create(realRow, realColumn);
        }

	}
}
