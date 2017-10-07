using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoucheMetier
{
    class TablePingPong
    {
        public int num_table { get; set; }
        public int position { get; set; }

        public TablePingPong() { }

        public TablePingPong(TablePingPong table)
        {
            num_table = table.num_table;
            position = table.position;
        }

        public TablePingPong( int Num_table,int Position)
        {
            num_table = Num_table;
            position = Position;
        }
    }
        }
   
