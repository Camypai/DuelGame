using Duel.Models;
using Duel.ScriptableObjects;


namespace Duel.Entities
{
    public class Board
    {
        private Cell[,] _cells = new Cell[2,5];

        public Board(BoardObject boardObject)
        {
            var row = 0;
            var column = 0;

            foreach (var cellObject in boardObject.CellsForFirstPlayer)
            {
                if (column == 4)
                {
                    row++;
                    column = 0;
                }
                
                _cells[row, column] = new Cell(cellObject);

                column++;
            }
        }

        public void PutItemToBoard(ItemModel item, CellModel cellModel)
        {
            _cells[cellModel.row, cellModel.column].PutItem(item);
        }

        public void PlayBoard()
        {
            foreach (var cell in _cells)
            {
                cell.PlayItem();
            }
        }
    }
}