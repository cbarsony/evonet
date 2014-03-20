using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoNet.Organic;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Genom genom = Incubator.CreateGenom(12, 10);
            List<Cell> cells = new List<Cell>();
            cells.Add(new Cell(1L));
            long counter = 2L;
            for (int j = 0; j < 12; j++)
            {
                List<Cell> newCells = new List<Cell>();
                for (int i = 0; i < cells.Count; i++)
                {
                    if (cells[i].fissing)
                    {
                        //Console.WriteLine("Fissing: " + cells[i].id);
                        newCells.Add(new Cell(counter++, cells[i]));
                        if (cells[i].id % (genom.genes[j] + 1) == 0)
                        {
                            //Console.WriteLine("Toggling: " + cells[i].id + ", gene: " + (genom.genes[j] + 1));
                            cells[i].fissing = !cells[i].fissing;
                        }
                    }
                }
                cells.AddRange(newCells);
            }
            cells[0].neighbors.Add(cells[cells.Count - 1]);
            Dictionary<long, long> book = new Dictionary<long, long>();
            TextWriter tw = new StreamWriter("nodes.gml");
            tw.WriteLine("graph\n[\n\tnode\n\t[\n\t\tid 1 label 1\n\t]");
            foreach (Cell cell in cells)
            {
                foreach (Cell neighbor in cell.neighbors)
                {
                    if (cell.id > neighbor.id)
                    {
                        tw.WriteLine("\tnode\n\t[\n\t\tid " + cell.id + " label " + cell.id + "\n\t]\n\tedge\n\t[\n\t\tsource " + cell.id + " target " + neighbor.id + "\n\t]");
                    }
                }
                //if (cell.ancestor != null)
                //{
                //    if (book.Keys.Contains(cell.ancestor.id))
                //    {
                //        book[cell.ancestor.id]++;
                //    }
                //    else
                //    {
                //        book.Add(cell.ancestor.id, 1);
                //    }
                //    Console.WriteLine(cell.id + ": " + cell.ancestor.id);
                //}
            }
            tw.WriteLine("]");
            tw.Flush();
            foreach (KeyValuePair<long, long> entry in book)
            {
                Console.WriteLine(entry.Key + " has " + entry.Value + " children");
            }
            Console.ReadKey();
        }
    }
}
