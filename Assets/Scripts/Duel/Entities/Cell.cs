using Duel.Models;
using Duel.ScriptableObjects;


namespace Duel.Entities
{
    public class Cell
    {
        private Item _item;
        
        public Cell(CellObject cellObject)
        {
            
        }

        public void PutItem(ItemModel item)
        {
            _item = new Item(item);
        }

        public void PlayItem()
        {
            _item.Play();
        }
    }
}