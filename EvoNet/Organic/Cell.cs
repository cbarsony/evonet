using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoNet.Organic
{
    public class Cell
    {
        public long id;
        public List<Cell> neighbors;
        public bool fissing = true;

        public Cell(long id)
        {
            this.id = id;
            this.neighbors = new List<Cell>();
        }

        public Cell(long id, Cell neighbor)
        {
            this.id = id;
            this.neighbors = new List<Cell>();
            this.neighbors.Add(neighbor);
        }
    }
}
