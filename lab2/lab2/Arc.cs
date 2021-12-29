using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Arc
    {
        public int arcWeight;

        //в точках дуги храним сами узлы

        private Vertex _vertex1;
        private Vertex _vertex2;

        public int Vertex1Mark
        {
            get
            {
                return _vertex1.mark;
            }
        }

        public int Vertex2Mark
        {
            get
            {
                return _vertex2.mark;
            }
        }

        public string Vertex1Name
        {
            get
            {
                return _vertex1.name;
            }
        }

        public string Vertex2Name
        {
            get
            {
                return _vertex2.name;
            }
        }
        public Arc(Vertex vertex1, Vertex vertex2, int arcWeight)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            this.arcWeight = arcWeight;
        }
    }
}
